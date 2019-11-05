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
    /// Ͱ��Website���йܣ����á�
    /// </summary>
    public class WebsiteConfiguration
    {

        private IList<RoutingRule> routingRules;
        /// <summary>
        /// �йܴ���ҳ�档
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string ErrorDocument
        {
            get;
            set;
        }

        /// <summary>
        /// �й���ҳ��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ,���ֶα�׷���ڶ��ļ��е������ĩβ�����磺���õ��ǡ�index.html����������ǡ�samplebucket/images/����
        /// ���ص����ݽ��ǡ�samplebucket��Ͱ����Ϊ��images/index.html���Ķ�������ݣ������ֶβ���Ϊ�ջ��߰�����/���ַ���
        /// </para>
        /// </remarks>
        public string IndexDocument
        {
            get;
            set;
        }

        /// <summary>
        ///���������ض������á�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public RedirectBasic RedirectAllRequestsTo
        {
            get;
            set;
        }

        /// <summary>
        /// �����ض�������б�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ����ErrorDocument��IndexDocument���ʹ�ã�������RedirectAllRequestsToһ��ʹ�á�
        /// </para>
        /// </remarks>
        public IList<RoutingRule> RoutingRules
        {
            get {
                
                return this.routingRules ?? (this.routingRules = new List<RoutingRule>()); }
            set { this.routingRules = value; }
        }

    }
}
