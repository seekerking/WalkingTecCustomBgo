using System.IO;
using System.Net;
using System.Text;

namespace AppSys.Framework
{
    #region

    #endregion

    /// <summary>
    /// 响应模型
    /// </summary>
    public class ResponseModel
    {
        internal ResponseModel()
        {
            ResponseHeader = new HttpHeader();
        }
        /// <summary>
        /// 响应头
        /// </summary>
        public HttpHeader ResponseHeader { get; set; }

        public string Body { get; set; }
    }

    /// <summary>
    /// 响应头实体
    /// </summary>
    public class HttpHeader
    {
        /// <summary>
        /// Http状态码
        /// </summary>
        public int HttpStatuCode { get; set; }
    }

    /// <summary>
    /// Http模拟请求
    /// </summary>
    public class HttpWebRequestHelper
    {
        static HttpWebRequestHelper()
        {
            ServicePointManager.DefaultConnectionLimit = 1024;
        }

        /// <summary>
        /// 默认内容类型
        /// </summary>
        private const string DefaultContentType = "application/json";

        /// <summary>
        /// 默认请求类型
        /// </summary>
        private const string DefaultMethod = "GET";

        /// <summary>
        /// 默认编码类型
        /// </summary>
        private const string DefaultEncodeType = "UTF-8";

        /// <summary>
        /// 创建HttpWebRequest
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private HttpWebRequest CreateRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            request.ContentType = DefaultContentType;
            request.Method = DefaultMethod;
            request.Accept = "*/*";
            request.Timeout = 30000;
            request.AllowAutoRedirect = false;
            return request;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public ResponseModel HttpPost(string url, string postData)
        {
            return HttpPost(url, postData, DefaultEncodeType);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public ResponseModel HttpPost(string url, string postData, string sign)
        {
            return HttpPost(url, postData, DefaultEncodeType, sign);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="encodeType"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public ResponseModel HttpPost(string url, string postData, string encodeType, string sign)
        {
            var request = CreateRequest(url);
            request.Method = "POST";
            if (!string.IsNullOrWhiteSpace(sign))
            {
                request.Headers.Add("Authorization", "Basic Sign=" + sign);
                request.Headers.Add("AwardSysApi-Version", "2");
            }
            var encode = Encoding.GetEncoding(encodeType);
            var byteContent = encode.GetBytes(postData);
            using (var stream = request.GetRequestStream())
            {
                stream.Write(byteContent, 0, byteContent.Length);
            }

            return ResponseModel(request, encode);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ResponseModel HttpGet(string url)
        {
            return HttpGet(url, DefaultEncodeType);
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encodeType"></param>
        /// <returns></returns>
        public ResponseModel HttpGet(string url, string encodeType)
        {
            var request = CreateRequest(url);
            var encode = Encoding.GetEncoding(encodeType);
            return ResponseModel(request, encode);
        }

        public System.Threading.ManualResetEvent allDone = new System.Threading.ManualResetEvent(false);
        /// <summary>
        /// 获取响应实体
        /// </summary>
        /// <param name="request"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private ResponseModel ResponseModel(HttpWebRequest request, Encoding encode)
        {
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                ResponseModel responseModel = new ResponseModel();
                using (var responseStream = response.GetResponseStream())
                {
                    responseModel.ResponseHeader.HttpStatuCode = (int)response.StatusCode;
                    if (responseStream == null)
                    {
                        responseModel.Body = response.StatusDescription;
                        return responseModel;
                    }
                    using (var reader = new StreamReader(responseStream, encode))
                    {
                        responseModel.Body = reader.ReadToEnd();
                        return responseModel;
                    }
                }
            }
        }
    }
}