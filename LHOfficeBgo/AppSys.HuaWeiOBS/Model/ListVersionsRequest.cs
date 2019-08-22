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
    /// �о�Ͱ�ڶ�汾��������������
    /// </summary>
    public class ListVersionsRequest : ObsBucketWebServiceRequest
    {

        internal override string GetAction()
        {
            return "ListVersions";
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
        /// �оٶ�汾�������ʼλ�ã������������򣩡�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// ���صĶ����б��Ƕ����������ֵ��������ò����Ժ�����ж���
        /// </para>
        /// </remarks>
        public string KeyMarker
        {
            get;
            set;
        }



        /// <summary>
        /// �оٶ�汾����������Ŀ����
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// ȡֵ��ΧΪ1~1000����������Χʱ������Ĭ�ϵ�1000���д���
        /// </para>
        /// </remarks>
        public int? MaxKeys
        {
            get;
            set;
        }


        /// <summary>
        /// �оٶ�汾����ʱ�Ķ�����ǰ׺��
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



        /// <summary>
        /// �оٶ�汾�������ʼλ�ã�������汾�����򣩡�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// ��KeyMarker���ʹ�ã����صĶ����б��Ƕ������Ͱ汾�Ű����ֵ��������ò����Ժ�����ж���
        /// ���VersionIdMarker����KeyMarker��һ���汾�ţ���ò�����Ч��
        /// </para>
        /// </remarks>
        public string VersionIdMarker
        {
            get;
            set;
        }

    }
}

