/*----------------------------------------------------------------------------------
// Copyright 2019 Huawei Technologies Co.,Ltd.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License.  You may obtain a copy of the
// License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations under the License.
//----------------------------------------------------------------------------------*/

namespace OBS.Model
{
    /// <summary>
    /// 列举已上传段的请求参数。
    /// </summary>
    public class ListPartsRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "ListParts";
        }

        /// <summary>
        /// 对象名。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        ///  </para> 
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }

        /// <summary>
        /// 列举已上传的段返回结果最大段数目。  
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        ///  </para> 
        /// </remarks>
        public int? MaxParts
        {
            get;
            set;
        }

        /// <summary>
        /// 待列出段的起始位置。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数可选。
        ///  </para> 
        /// </remarks>
        public int? PartNumberMarker
        {
            get;
            set;
        }


        /// <summary>
        /// 分段上传任务的ID号。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 参数必选。
        ///  </para> 
        /// </remarks>
        public string UploadId
        {
            get;
            set;
        }

    }
}
    
