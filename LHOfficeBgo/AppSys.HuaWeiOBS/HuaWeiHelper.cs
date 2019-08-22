using System;
using System.IO;
using OBS;
using OBS.Model;

namespace esdk_obs_.net_core
{
  public  static class HuaWeiHelper
    {
        private static string endpoint = "https://obs.cn-north-4.myhuaweicloud.com";
        private static string AK = "XUGWR6RI34BX4IPB6KBN";
        private static string SK = "ycHfTd2ehvE4ToEqEBCoBn0CmTDa9erfw9CXWefJ";

        private static ObsClient client;
        private static ObsConfig config;

        private static string bucketName = "obs-wnl-images-public";
        private static string objectName = "install.png";

        static HuaWeiHelper()
        {
            client = new ObsClient(AK, SK, endpoint);
        }

        public static string PutFileWithStream(Stream fstream, string remoteFileName, string reptxt = "obs-wnl-images-public.obs.cn-north-4.myhuaweicloud.com", string newreptxt = "huaweiyun.51wnl-cq.com")
        {

            string url = string.Empty;
            try
            {
                objectName = remoteFileName;
              

                PutObjectRequest request = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    ObjectKey = objectName,
                    //FilePath = filePath,
                    InputStream = fstream
                };
                PutObjectResponse response = client.PutObject(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    url = response.ObjectUrl.Replace(reptxt, newreptxt);
                }

            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when put object.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
            return url;
        }

    }
}
