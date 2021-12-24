﻿using Authing.ApiClient.Domain.Model;
using Authing.ApiClient.Domain.Model.Authentication;
using Authing.ApiClient.Domain.Model.Management.Mfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.ApiClient.Interfaces.AuthenticationClient
{
    public interface IMfaAuthenticationClient
    {
        /// <summary>
        /// 获取 MFA 认证器
        /// </summary>
        /// <param name="getMfaAuthenticatorsParam"></param>
        /// <returns></returns>
        public Task<List<IMfaAuthenticator>> GetMfaAuthenticators(GetMfaAuthenticatorsParam getMfaAuthenticatorsParam);

        /// <summary>
        /// 请求 MFA 二维码和密钥信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Task<IMfaAssociation> AssosicateMfaAuthenticator(AssosicateMfaAuthenticatorParam parameter);

        /// <summary>
        ///解绑 MFA
        /// </summary>
        /// <returns></returns>
        public Task<CommonMessage> DeleteMfaAuthenticator();

        /// <summary>
        /// 确认绑定 MFA
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>

        public Task<CommonMessage> ConfirmAssosicateMfaAuthenticator(ConfirmAssosicateMfaAuthenticatorParam parameter);

        /// <summary>
        /// 检验二次验证 MFA 口令
        /// </summary>
        /// <param name="verifyTotpMfaParam"></param>
        /// <returns></returns>
        public Task<User> VerifyTotpMfa(VerifyTotpMfaParam verifyTotpMfaParam);

        /// <summary>
        /// 检验二次验证 MFA 短信验证码
        /// </summary>
        /// <param name="verifyAppSmsMfaParam"></param>
        /// <returns></returns>
        public Task<User> VerifyAppSmsMfa(VerifyAppSmsMfaParam verifyAppSmsMfaParam);

        /// <summary>
        /// 检验二次验证 MFA 邮箱验证码
        /// </summary>
        /// <param name="verifyAppEmailMfaParam"></param>
        /// <returns></returns>
        public Task<User> VerifyAppEmailMfa(VerifyAppEmailMfaParam verifyAppEmailMfaParam);

        /// <summary>
        /// 检测手机号或邮箱是否已被绑定
        /// </summary>
        /// <param name="phoneOrEmailBindableParam"></param>
        /// <returns></returns>
        public Task<bool> PhoneOrEmailBindable(PhoneOrEmailBindableParam phoneOrEmailBindableParam);

        /// <summary>
        /// 检验二次验证 MFA 恢复代码
        /// </summary>
        /// <param name="verifyTotpRecoveryCodeParam"></param>
        /// <returns></returns>
        public Task<User> VerifyTotpRecoveryCode(VerifyTotpRecoveryCodeParam verifyTotpRecoveryCodeParam);

        /// <summary>
        /// 通过图片 URL 绑定人脸
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<User> AssociateFaceByUrl(AssociateFaceByUrlParams options);

        /// <summary>
        /// 人脸二次认证
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="mfaToken"></param>
        /// <returns></returns>
        public Task<User> VerifyFaceMfa(string photo, string mfaToken);
       
    }
}
