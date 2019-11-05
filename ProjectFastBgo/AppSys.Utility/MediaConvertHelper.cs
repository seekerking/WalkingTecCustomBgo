using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Enums;

namespace AppSys.Utility
{
    public class MediaConvertHelper
    {

        public static ConcurrentQueue<FileInfo> UploadWaitConvertMedias=new ConcurrentQueue<FileInfo>();
        public Dictionary<string, string> audioTranslationCode = new Dictionary<string, string>();
        private const string SourceFile = "sourceFile";
        private const string SourceFormat = "sourceFormat";
        private const string MutilThreads = "mutilThreads";
        private const string Speed = "speed";
        private const string CodeFormat = "codeformat";
        private const string AudioChannel = "audioChannel";
        private const string AudioSmapleRate = "audioSampleRate";
        private const string CodeEngine = "codeEngine";
        private const string OutPutFileName = "outPutFileName";
        private const string BitRates = "bitRates";

        /// <summary>
        /// amr转wav
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="outputExtension"></param>
        /// <returns></returns>
        public async Task<FileInfo> ConvetAudioStreamExtensionTo(FileInfo sourceFile,string dir = "Upload", string outputExtension = ".pcm")
        {
            try
            {
                var targetPath = $"{Guid.NewGuid().ToString()}_Copy{outputExtension}";
                var conversion = Conversion.New();
                SetSourceAudio(sourceFile);
                //如果输入是pcm需要添加
                // SetSourceFormat(" -f s16le -ac 1 -ar 32000 ");
                SetMutialThread(true);
                SetPresetSpeed("ultrafast");
                SetCodeEngine("pcm_s16le");
                SetCodeFormat("s16le");
                SetBitRates(24000);
                SetAudioChannel(1);
                SetAudioSampleRate(16000);
                SetOutPutFileName($"Upload/{targetPath}");
                var result= await conversion.Start(Build()).ConfigureAwait(false);
                FileInfo targetFile = new FileInfo($"{dir}/" + targetPath);
                return targetFile;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string Build()
        {

            StringBuilder parameter = new StringBuilder();

            parameter.Append(" -y ");
            if (audioTranslationCode.ContainsKey(SourceFile))
            {
                parameter.Append(audioTranslationCode[SourceFile]);
            }

            if (audioTranslationCode.ContainsKey(SourceFormat))
            {
                parameter.Append(audioTranslationCode[SourceFormat]);
            }
            if (audioTranslationCode.ContainsKey(BitRates))
            {
                parameter.Append(audioTranslationCode[BitRates]);
            }

            if (audioTranslationCode.ContainsKey(CodeEngine))
            {
                parameter.Append(audioTranslationCode[CodeEngine]);
            }
            if (audioTranslationCode.ContainsKey(CodeFormat))
            {
                parameter.Append(audioTranslationCode[CodeFormat]);
            }
            if (audioTranslationCode.ContainsKey(AudioChannel))
            {
                parameter.Append(audioTranslationCode[AudioChannel]);
            }
            if (audioTranslationCode.ContainsKey(AudioSmapleRate))
            {
                parameter.Append(audioTranslationCode[AudioSmapleRate]);
            }
            if (audioTranslationCode.ContainsKey(OutPutFileName))
            {
                parameter.Append(audioTranslationCode[OutPutFileName]);
            }


            return parameter.ToString();



        }

        private void SetSourceAudio(FileInfo sourceFile)
        {
            audioTranslationCode[SourceFile] = $"-i \"{sourceFile.FullName}\"";
        }

        private void SetBitRates(double bitrates)
        {
            if (bitrates != 0)
            {
                audioTranslationCode[BitRates] =$" -b:a {bitrates} ";
            }
        }

        private void SetSourceFormat(string foramt)
        {
            audioTranslationCode[SourceFormat] = foramt;
        }

        private void SetMutialThread(bool flag)
        {
            if (flag)
            {
                audioTranslationCode[MutilThreads] = " -threads 4 ";
            }
        }

        private void SetCodeEngine(string codeEngine)
        {
            if (!codeEngine.IsNullOrEmpty())
            {
                audioTranslationCode[CodeEngine] = $" -acodec {codeEngine} ";
            }
        }
        private void SetCodeFormat(string codeFormat)
        {
            if (!codeFormat.IsNullOrEmpty())
            {
                audioTranslationCode[CodeFormat] = $" -f {codeFormat}  ";
            }
        }

        private void SetAudioChannel(int channel)
        {
            if (channel != 0)
            {
                audioTranslationCode[AudioChannel] = $"-ac  {channel} ";
            }
        }

        private void SetAudioSampleRate(int rate)
        {
            if (rate != 0)
            {
                audioTranslationCode[AudioSmapleRate] = $" -ar {rate} ";
            }
        }

        private void SetOutPutFileName(string outPutFileName)
        {
            if (!outPutFileName.IsNullOrEmpty())
            {
                audioTranslationCode[OutPutFileName] = $" \"{outPutFileName}\" ";
            }
        }

        private void SetPresetSpeed(string preset)
        {
            if (!preset.IsNullOrEmpty())
            {
                audioTranslationCode[Speed] = $" -preset {preset} ";
            }
        }
    }

    public class MediaConvertGroup
    {
        public FileInfo SourceFile { get; set; }
        public FileInfo DestFile { get; set; }
    }
}
