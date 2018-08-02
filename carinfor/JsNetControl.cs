using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LineClient;
using System.Runtime.InteropServices;

namespace carinfor
{
    public static class JsNetControl
    {
        /// <summary>
        /// 1、	连接检测机构服务器，调用ConnectServer函数
        /// </summary>
        /// <param name="status">bool型，返回连接状态：true，false。true连接成功，false连接失败。</param>
        /// <param name="errMsg">字符串，连接失败时返回失败原因</param>
        [DllImport("LineClient.dll")]
        
        public static extern void ConnectServer(out bool status,out string errMsg);

        /// <summary>
        /// 1、	检测软件需设置登陆界面，登陆界面录入用户名和密码，调用LoginServer函数。该函数需在ConnectServer成功后方可正确调用。
        /// </summary>
        /// <param name="userName">字符串型，检测人员用户名</param>
        /// <param name="password">字符串型，检测人员密码</param>
        /// <param name="status">bool型，返回登陆状态：true，false。true成功，false失败。</param>
        /// <param name="errMsg">字符串，登陆失败时返回失败原因。</param>
        [DllImport("LineClient.dll")]
        public static extern void LoginServer(string userName, string password,out bool status,out string errMsg);

        /// <summary>
        /// 1、	修改检测用户的用户密码，需调用LoginServer成功后，才可正确调用ChangePassword。调用ChangePassword后，需使用新密码重新调用LoginServer登录。
        /// </summary>
        /// <param name="userName">字符串型，检测人员用户名。</param>
        /// <param name="password">字符串型，检测人员密码。</param>
        /// <param name="newPassword">字符串型，检测人员新密码。</param>
        /// <param name="status">bool型，返回登陆状态：true，false。True修改成功，false修改失败。</param>
        /// <param name="errMsg">字符串，登陆失败时返回失败原因。</param>
        [DllImport("LineClient.dll")]
        
        public static extern void ChangePassword(string userName, string password,string newPassword, out bool status, out string errMsg);

        /// <summary>
        /// 1、	检测软件需定时同步数据字典内容（检测检测软件启动时调用）到本地，调用GetBaseTypeInfo函数。该函数调用在ConnectServer、LoginServer成功后方可正常调用。
        /// </summary>
        /// <param name="xmlBaseTypeInfo">字符串型，返回xml字符串，定义环保检测所需检测线相关数据及数据字典。</param>
        /// <param name="status">bool型，返回获取状态：true，false。true成功，false失败。</param>
        /// <param name="errMsg">字符串，获取失败时返回失败原因。</param>
        [DllImport("LineClient.dll")]

        public static extern void GetBaseTypeInfo(out string xmlBaseTypeInfo,out bool status, out string errMsg);

        /// <summary>
        /// 1、	开始检测时需调用被检车辆相关信息，调用GetVehicleInfo函数。
        /// </summary>
        /// <param name="plate">字符串型，车牌号码，如果车牌号码末尾是汉字请截除。</param>
        /// <param name="plateColor">字符串型，号牌颜色，传入字典表中PLATE_TYPE定义的代码。</param>
        /// <param name="vehicleInfoString">字符串型，返回xml字符串，被检测车辆信息</param>
        /// <param name="checkLimit">字符串型，返回xml字符串，被检测车辆检测限值信息。</param>
        /// <param name="status">bool型，返回获取状态：true，false。true成功，false失败。</param>
        /// <param name="errMsg">字符串，获取失败时返回失败原因。</param>
        [DllImport("LineClient.dll")]

        public static extern void GetVehicleInfo(string plate, string  plateColor, out string vehicleInfoString,out string checkLimit,out bool status, out string errMsg);

        /// <summary>
        /// 1、	开始标定，调用BeginDemarcate函数
        /// </summary>
        /// <param name="demarcateLimit">字符串型，返回xml字符串，定义标定限值。</param>
        /// <param name="status">bool型，返回状态：true，false。true成功，false失败。</param>
        /// <param name="errMsg">字符串，失败时返回失败原因。</param>
        [DllImport("LineClient.dll")]

        public static extern void BeginDemarcate(out string demarcateLimit, out bool status, out string errMsg);

        /// <summary>
        /// 1、	上传标定结果，调用UploadDemarcateResult函数。
        /// </summary>
        /// <param name="demarcateResult">字符串型，以xml字符串传入标定结果。</param>
        /// <param name="status">bool型，返回状态：true，false。true成功，false失败。</param>
        /// <param name="errMsg">字符串，失败时返回失败原因。</param>
        [DllImport("LineClient.dll")]

        public static extern void UploadDemarcateResult(string demarcateResult, out bool status, out string errMsg);

        /// <summary>
        /// 开始检测，调用BeginInspection函数
        /// </summary>
        /// <param name="inspType">字符串型，传入检测类型（检测类型在字典数据中定义）</param>
        /// <param name="stationId">字符串型，返回检测站编号。</param>
        /// <param name="lineId">字符串型，返回检测线编号。</param>
        /// <param name="inspectionId">字符串型，返回检测编号。</param>
        /// <param name="status">bool型，返回状态：true，false。true成功，false失败。</param>
        /// <param name="errMsg">字符串，失败时返回失败原因。</param>
        [DllImport("LineClient.dll")]

        public static extern void BeginInspection(string inspType,string stationId,string lineId,string inspectionId, out bool status, out string errMsg);

        /// <summary>
        /// 1、	结束检测，调用StopInspection函数
        /// </summary>
        /// <param name="status">bool型，返回状态：true，false。true成功，false失败。</param>
        /// <param name="errMsg">字符串，失败时返回失败原因。</param>
        [DllImport("LineClient.dll")]

        public static extern void StopInspection( out bool status, out string errMsg);

        /// <summary>
        /// 1、	上传检测结果，调用UploadInspectionResult函数。
        /// </summary>
        /// <param name="inspectionResult">字符串型，以xml字符串传入检测结果。</param>
        /// <param name="finalResult">字符串型，返回最终检测结果判定，检测是否合格以该变量值为准。</param>
        /// <param name="status">bool型，返回检测结果上传状态：true，false。trues上传成功，false上传失败。</param>
        /// <param name="cardWriteStatus">bool型，返回电子卡写卡状态：true，false。Trues写卡成功，false写卡失败。如果cardWriteStatus为false，请检测程序弹出电子卡写卡失败对话框。</param>
        /// <param name="errMsg">字符串，上传失败时返回失败原因（电子卡写卡失败不返回原因）。</param>
        [DllImport("LineClient.dll")]

        public static extern void UploadInspectionResult(string inspectionResult,out string finalResult,out bool status,out bool cardWriteStatus, out string errMsg);

    }
}
