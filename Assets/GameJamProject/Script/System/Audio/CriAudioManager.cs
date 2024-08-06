// using System;
// using System.Collections.Generic;
// using CriWare;
// using Cysharp.Threading.Tasks;
// using GameJamProject.System;
// using UnityEngine;
//
// namespace GameJamProject.Audio
// {
//     public class CriAudioManager : Singleton<CriAudioManager>
//     {
//         [SerializeField] private string _streamingAssetsPathAcf = "AcquireSummerGameJamEarthTeam";
//         [SerializeField] private string _cueSheetBGM = "CueSheet_BGM"; //.acb
//         [SerializeField] private string _cueSheetSe = "CueSheet_SE"; //.acb
//         [SerializeField] private string _cueSheetVoice = "CueSheet_Voice"; //.acb
//
//         protected override bool UseDontDestroyOnLoad => true;
//
//         private float _masterVolume = 1F;
//         private float _bgmVolume = 1F;
//         private float _seVolume = 1F;
//         private float _voiceVolume = 1F;
//         private const float Diff = 0.01F; //音量の変更があったかどうかの判定に使う
//
//         /// <summary>マスターボリュームが変更された際に呼ばれるEvent</summary>
//         public Action<float> MasterVolumeChanged;
//
//         /// <summary>BGMボリュームが変更された際に呼ばれるEvent</summary>
//         public Action<float> BGMVolumeChanged;
//
//         /// <summary>SEボリュームが変更された際に呼ばれるEvent</summary>
//         public Action<float> SEVolumeChanged;
//
//         /// <summary>Voiceボリュームが変更された際に呼ばれる処理</summary>
//         public Action<float> VoiceVolumeChanged;
//
//         private CriAtomExPlayer _bgmPlayer;
//         private CriAtomExPlayback _bgmPlayback;
//
//         private CriAtomExPlayer _sePlayer;
//         private CriAtomExPlayer _loopSEPlayer;
//         private List<CriPlayerData> _seData;
//
//         private CriAtomExPlayer _voicePlayer;
//         private List<CriPlayerData> _voiceData;
//
//         private string _currentBGMCueName = "";
//         private CriAtomExAcb _currentBGMAcb = null;
//
//         /// <summary>マスターボリューム</summary>
//         /// <value>変更したい値</value>
//         public float MasterVolume
//         {
//             get => _masterVolume;
//             set
//             {
//                 if (!(_masterVolume + Diff < value) && !(_masterVolume - Diff > value)) return;
//                 MasterVolumeChanged.Invoke(value);
//                 _masterVolume = value;
//             }
//         }
//
//         /// <summary>BGMボリューム</summary>
//         /// <value>変更したい値</value>
//         public float BGMVolume
//         {
//             get => _bgmVolume;
//             set
//             {
//                 if (!(_bgmVolume + Diff < value) && !(_bgmVolume - Diff > value)) return;
//                 BGMVolumeChanged.Invoke(value);
//                 _bgmVolume = value;
//             }
//         }
//
//         /// <summary>マスターボリューム</summary>
//         /// <value>変更したい値</value>
//         public float SEVolume
//         {
//             get => _seVolume;
//             set
//             {
//                 if (!(_seVolume + Diff < value) && !(_seVolume - Diff > value)) return;
//                 SEVolumeChanged.Invoke(value);
//                 _seVolume = value;
//             }
//         }
//
//         public float VoiceVolume
//         {
//             get => _voiceVolume;
//             set
//             {
//                 if (!(_voiceVolume + Diff < value) && !(_voiceVolume - Diff > value)) return;
//                 VoiceVolumeChanged.Invoke(value);
//                 _voiceVolume = value;
//             }
//         }
//
//         /// <summary>SEのPlayerとPlaback</summary>
//         private struct CriPlayerData
//         {
//             private CriAtomExPlayback _playback;
//             private CriAtomEx.CueInfo _cueInfo;
//
//
//             public CriAtomExPlayback Playback
//             {
//                 get => _playback;
//                 set => _playback = value;
//             }
//
//             public CriAtomEx.CueInfo CueInfo
//             {
//                 get => _cueInfo;
//                 set => _cueInfo = value;
//             }
//
//             public bool IsLoop
//             {
//                 get => _cueInfo.length < 0;
//             }
//         }
//
//
//         /// <summary>CriAtom の追加。acb追加</summary>
//         protected override async void OnAwake()
//         {
//             //await LoadAcfAndAcb();
//             // acf設定
//             string path = Application.streamingAssetsPath + $"/{_streamingAssetsPathAcf}.acf";
//             CriAtomEx.RegisterAcf(null, path);
//             // CriAtom作成
//             gameObject.AddComponent<CriAtom>();
//             // BGM acb追加
//             CriAtom.AddCueSheet(_cueSheetBGM, $"{_cueSheetBGM}.acb", null, null);
//             // SE acb追加
//             CriAtom.AddCueSheet(_cueSheetSe, $"{_cueSheetSe}.acb", null, null);
//             //Voice acb追加
//             CriAtom.AddCueSheet(_cueSheetVoice, $"{_cueSheetVoice}.acb", null, null);
//
//             _bgmPlayer = new CriAtomExPlayer();
//             _sePlayer = new CriAtomExPlayer();
//             _loopSEPlayer = new CriAtomExPlayer();
//             _voicePlayer = new CriAtomExPlayer();
//
//             _seData = new List<CriPlayerData>();
//             _voiceData = new List<CriPlayerData>();
//
//             MasterVolumeChanged += volume =>
//             {
//                 _bgmPlayer.SetVolume(volume * _bgmVolume);
//                 _bgmPlayer.Update(_bgmPlayback);
//
//                 foreach (var se in _seData)
//                 {
//                     if (se.IsLoop)
//                     {
//                         _loopSEPlayer.SetVolume(volume * _seVolume);
//                         _loopSEPlayer.Update(se.Playback);
//                     }
//                     else
//                     {
//                         _sePlayer.SetVolume(volume * _seVolume);
//                         _sePlayer.Update(se.Playback);
//                     }
//                 }
//
//
//                 foreach (var voice in _voiceData)
//                 {
//                     _voicePlayer.SetVolume(_masterVolume * volume);
//                     _voicePlayer.Update(voice.Playback);
//                 }
//             };
//
//             BGMVolumeChanged += volume =>
//             {
//                 _bgmPlayer.SetVolume(_masterVolume * volume);
//                 _bgmPlayer.Update(_bgmPlayback);
//             };
//
//             SEVolumeChanged += volume =>
//             {
//                 foreach (var se in _seData)
//                 {
//                     if (se.IsLoop)
//                     {
//                         _loopSEPlayer.SetVolume(_masterVolume * volume);
//                         _loopSEPlayer.Update(se.Playback);
//                     }
//                     else
//                     {
//                         _sePlayer.SetVolume(_masterVolume * volume);
//                         _sePlayer.Update(se.Playback);
//                     }
//                 }
//             };
//
//             VoiceVolumeChanged += volume =>
//             {
//                 foreach (var voice in _voiceData)
//                 {
//                     _voicePlayer.SetVolume(_masterVolume * volume);
//                     _voicePlayer.Update(voice.Playback);
//                 }
//             };
//         }
//
//         private async UniTask LoadAcfAndAcb()
//         {
//             // ACF読み込み
//             TextAsset acfTextAsset = Resources.Load<TextAsset>(_streamingAssetsPathAcf);
//             if (acfTextAsset != null)
//             {
//                 byte[] acfData = acfTextAsset.bytes;
//                 CriAtomEx.RegisterAcf(acfData);
//             }
//             else
//             {
//                 Debug.LogWarning($"ACF file {_streamingAssetsPathAcf} not found in Resources.");
//             }
//
//             // CriAtom作成
//             gameObject.AddComponent<CriAtom>();
//
//             // ACB読み込み
//             await LoadAcb(_cueSheetBGM);
//             await LoadAcb(_cueSheetSe);
//             await LoadAcb(_cueSheetVoice);
//
//             CriAtom.AttachDspBusSetting("DspBusSetting_0");
//         }
//
//         private async UniTask LoadAcb(string cueSheetName)
//         {
//             TextAsset acbTextAsset = Resources.Load<TextAsset>(cueSheetName + ".bytes");
//             if (acbTextAsset != null)
//             {
//                 byte[] acbData = acbTextAsset.bytes;
//                 CriAtom.AddCueSheet(cueSheetName, acbData, null);
//                 var cueSheet = CriAtom.GetCueSheet(cueSheetName);
//                 while (cueSheet.IsLoading)
//                 {
//                     await UniTask.Yield();
//                 }
//             }
//             else
//             {
//                 Debug.LogWarning($"Cue sheet {cueSheetName} not found in Resources.");
//             }
//         }
//
//         protected override void OnDestroy()
//         {
//             CriAtomPlugin.FinalizeLibrary();
//         }
//
//         /// <summary>BGMを開始する</summary>
//         /// <param name="cueName">流したいキューの名前</param>
//         public void PlayBGM(string cueName)
//         {
//             var tempAcb = CriAtom.GetCueSheet(_cueSheetBGM).acb;
//             if (!tempAcb.GetCueInfo(cueName, out var cueInfo))
//             {
//                 Debug.LogError($"BGMキュー名 '{cueName}' がキューシート '{_cueSheetBGM}' に存在しません。");
//                 return;
//             }
//
//             if (_currentBGMCueName == cueName &&
//                 _bgmPlayer.GetStatus() == CriAtomExPlayer.Status.Playing)
//             {
//                 return;
//             }
//
//             StopBGM();
//             _bgmPlayer.SetCue(_currentBGMAcb, cueName);
//             _bgmPlayback = _bgmPlayer.Start();
//             _currentBGMCueName = cueName;
//         }
//
//         /// <summary>BGMを中断させる</summary>
//         public void PauseBGM()
//         {
//             if (_bgmPlayer.GetStatus() == CriAtomExPlayer.Status.Playing)
//             {
//                 _bgmPlayer.Pause();
//             }
//         }
//
//         /// <summary>中断したBGMを再開させる</summary>
//         public void ResumeBGM()
//         {
//             _bgmPlayer.Resume(CriAtomEx.ResumeMode.PausedPlayback);
//         }
//
//         /// <summary>BGMを停止させる</summary>
//         public void StopBGM()
//         {
//             if (_bgmPlayer.GetStatus() == CriAtomExPlayer.Status.Playing)
//             {
//                 _bgmPlayer.Stop();
//             }
//         }
//
//         /// <summary>SEを流す関数</summary>
//         /// <param name="cueName">流したいキューの名前</param>
//         /// <param name="volume">音量</param>
//         /// <returns>停止する際に必要なIndex</returns>
//         public int PlaySE(string cueName, float volume = 1f)
//         {
//             CriPlayerData newAtomPlayer = new CriPlayerData();
//
//             var tempAcb = CriAtom.GetCueSheet(_cueSheetSe).acb;
//             if (!tempAcb.GetCueInfo(cueName, out var cueInfo))
//             {
//                 Debug.LogError($"SEキュー名 '{cueName}' がキューシート '{_cueSheetSe}' に存在しません。");
//                 return -1;
//             }
//
//             newAtomPlayer.CueInfo = cueInfo;
//
//             if (newAtomPlayer.IsLoop)
//             {
//                 _loopSEPlayer.SetCue(tempAcb, cueName);
//                 _loopSEPlayer.SetVolume(volume * _seVolume * _masterVolume);
//                 newAtomPlayer.Playback = _loopSEPlayer.Start();
//             }
//             else
//             {
//                 _sePlayer.SetCue(tempAcb, cueName);
//                 _sePlayer.SetVolume(volume * _seVolume * _masterVolume);
//                 newAtomPlayer.Playback = _sePlayer.Start();
//             }
//
//             _seData.Add(newAtomPlayer);
//             return _seData.Count - 1;
//         }
//
//         /// <summary>SEをPauseさせる </summary>
//         /// <param name="index">一時停止させたいPlaySE()の戻り値 (-1以下を渡すと処理を行わない)</param>
//         public void PauseSE(int index)
//         {
//             if (index < 0) return;
//
//             _seData[index].Playback.Pause();
//         }
//
//         /// <summary>PauseさせたSEを再開させる</summary>
//         /// <param name="index">再開させたいPlaySE()の戻り値 (-1以下を渡すと処理を行わない)</param>
//         public void ResumeSE(int index)
//         {
//             if (index < 0) return;
//
//             _seData[index].Playback.Resume(CriAtomEx.ResumeMode.AllPlayback);
//         }
//
//         /// <summary>SEを停止させる </summary>
//         /// <param name="index">止めたいPlaySE()の戻り値 (-1以下を渡すと処理を行わない)</param>
//         public void StopSE(int index)
//         {
//             if (index < 0) return;
//
//             _seData[index].Playback.Stop();
//         }
//
//         /// <summary>ループしているすべてのSEを止める</summary>
//         public void StopLoopSE()
//         {
//             _loopSEPlayer.Stop();
//         }
//
//         /// <summary>Voiceを流す関数</summary>
//         /// <param name="cueSheet">流したいキューシートの名前</param>
//         /// <param name="cueName">流したいキューの名前</param>
//         /// <returns>停止する際に必要なIndex</returns>
//         public int PlayVoice(string cueName, float volume = 1f)
//         {
//             CriPlayerData newAtomPlayer = new CriPlayerData();
//             var tempAcb = CriAtom.GetCueSheet(_cueSheetSe).acb;
//             tempAcb.GetCueInfo(cueName, out var cueInfo);
//
//             newAtomPlayer.CueInfo = cueInfo;
//
//             _voicePlayer.SetCue(tempAcb, cueName);
//             _voicePlayer.SetVolume(volume * _masterVolume * _voiceVolume);
//             newAtomPlayer.Playback = _voicePlayer.Start();
//
//             _voiceData.Add(newAtomPlayer);
//             return _voiceData.Count - 1;
//         }
//
//         /// <summary>VoiceをPauseさせる </summary>
//         /// <param name="index">一時停止させたいPlayVoice()の戻り値 (-1以下を渡すと処理を行わない)</param>
//         public void PauseVoice(int index)
//         {
//             if (index < 0) return;
//
//             _voiceData[index].Playback.Pause();
//         }
//
//         /// <summary>PauseさせたVoiceを再開させる</summary>
//         /// <param name="index">再開させたいPlayVoice()の戻り値 (-1以下を渡すと処理を行わない)</param>
//         public void ResumeVoice(int index)
//         {
//             if (index < 0) return;
//
//             _voiceData[index].Playback.Resume(CriAtomEx.ResumeMode.AllPlayback);
//         }
//
//         /// <summary>Voiceを停止させる </summary>
//         /// <param name="index">止めたいPlayVoice()の戻り値 (-1以下を渡すと処理を行わない)</param>
//         public void StopVoice(int index)
//         {
//             if (index < 0) return;
//
//             _voiceData[index].Playback.Stop();
//         }
//     }
// }