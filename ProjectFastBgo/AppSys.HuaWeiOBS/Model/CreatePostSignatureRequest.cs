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
using System.Collections.Generic;
namespace OBS.Model
{
    /// <summary>
    /// POST����Ȩ��������� 
    /// </summary>
    public class CreatePostSignatureRequest : ObsBucketWebServiceRequest
    {

        private IDictionary<string, string> parameters;

        internal override string GetAction()
        {
            return "CreatePostSignature";
        }

        /// <summary>
        /// Ͱ����
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public override string BucketName
        {
            get;
            set;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string ObjectKey
        {
            get;
            set;
        }


        /// <summary>
        /// ����ʱ�䡣
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public DateTime? Expires
        {
            get;
            set;
        }


        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public IDictionary<String, String> FormParameters
        {
            get {
     
                return this.parameters ?? (this.parameters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            }
            set
            {
                this.parameters = value;
            }
        }


    }
}