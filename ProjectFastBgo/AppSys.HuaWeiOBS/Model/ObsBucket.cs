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
using System;

namespace OBS.Model
{
    /// <summary>
    /// Ͱ��Ϣ��
    /// </summary>
    public class ObsBucket
    {
        

        /// <summary>
        /// Ͱ�Ĵ���ʱ�䡣
        /// </summary>
        public DateTime? CreationDate
        {
            get;
            internal set;
        }

        /// <summary>
        /// Ͱ����
        /// </summary>
        public string BucketName
        {
            get;
            internal set;
        }

        /// <summary>
        /// Ͱ������λ��
        /// </summary>
        public string Location
        {
            get;
            internal set;
        }

        public override string ToString()
        {
            return "BucketName:" + BucketName + ", CreationDate:" + CreationDate + ", Location:" + Location;
        }

    }
}
