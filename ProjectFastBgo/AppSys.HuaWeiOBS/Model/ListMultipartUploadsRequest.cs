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
    /// �оٷֶ��ϴ���������������
    /// </summary>
    public class ListMultipartUploadsRequest : ObsBucketWebServiceRequest
    {


        internal override string GetAction()
        {
            return "ListMultipartUploads";
        }

        /// <summary>
        /// ���������з�����ַ���
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// ���ڶ������а���Delimiter������������������������ָ����Prefix����˴��Ķ�������Ҫȥ��Prefix��
        /// �д����ַ�����һ��Delimiter֮����ַ�������Ϊһ�����鲢��ΪCommonPrefix���ء�
        /// </para>
        /// </remarks>
        public string Delimiter
        {
            get;
            set;
        }



        /// <summary>
        /// �оٷֶ��ϴ��������ʼλ�ã������������򣩡�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// </para>
        /// </remarks>
        public string KeyMarker
        {
            get;
            set;
        }



        /// <summary>
        /// �оٷֶ��ϴ�����������Ŀ��  
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��
        /// ȡֵ��ΧΪ1~1000����������Χʱ������Ĭ�ϵ�1000���д���
        /// </para>
        /// </remarks>
        public int? MaxUploads
        {
            get;
            set;
        }



        /// <summary>
        /// �оٷֶ��ϴ�����Ķ�����ǰ׺��
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
        /// �оٷֶ��ϴ��������ʼλ�ã����ֶ��ϴ������ID�����򣩡�
        /// </summary>
        /// <remarks>
        /// <para>
        /// ������ѡ��ֻ����KeyMarker����һ��ʹ��ʱ�������壬����ָ�����ؽ������ʼλ�á�
        /// </para>
        /// </remarks>
        public string UploadIdMarker
        {
            get;
            set;
        }

    }
}
    
