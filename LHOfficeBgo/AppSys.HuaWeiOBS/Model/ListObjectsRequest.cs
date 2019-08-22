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
    /// �о�Ͱ�ڶ�������������
    /// </summary>
    public class ListObjectsRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "ListObjectsRequest";
        }


        /// <summary>
        /// ���������з�����ַ���
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// ���ڶ������а���Delimiter�Ķ���������������������ָ����Prefix����˴��Ķ�������Ҫȥ��Prefix��
        /// �д����ַ�����һ��Delimiter֮����ַ�������Ϊһ�����鲢��ΪCommonPrefix���ء�
        /// </para>
        /// </remarks>
        public string Delimiter
        {
            get;
            set;
        }



        /// <summary>
        /// �оٶ���ʱ����ʼλ�á�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// �оٶ������ʼλ�ã����صĶ����б����Ƕ����������ֵ��������ò����Ժ�����ж���
        /// </para>
        /// </remarks>
        public string Marker
        {
            get;
            set;
        }


        /// <summary>
        /// �оٶ���������Ŀ����
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��Ĭ���о����1000������
        /// </para>
        /// </remarks>
        public int? MaxKeys
        {
            get;
            set;
        }



        /// <summary>
        /// �оٶ���ʱ�Ķ�����ǰ׺��
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string Prefix
        {
            get;
            set;
        }

    }
}
    