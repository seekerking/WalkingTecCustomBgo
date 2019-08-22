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
using System.Collections.Generic;

namespace OBS.Model
{
    /// <summary>
    /// 获取桶列表的响应结果。
    /// </summary>
    public class ListBucketsResponse : ObsWebServiceResponse
    {
        private IList<ObsBucket> buckets;

        /// <summary>
        /// 桶列表。
        /// </summary>
        public IList<ObsBucket> Buckets
        {
            get {
                
                return this.buckets ?? (this.buckets = new List<ObsBucket>()); }
            internal set { this.buckets = value; }
        }

        /// <summary>
        /// 桶的所有者。
        /// </summary>
        public Owner Owner
        {
            get;
            internal set;
        }

    }
}
    
