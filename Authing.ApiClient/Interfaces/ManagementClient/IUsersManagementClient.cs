using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Authing.ApiClient.Domain.Model;
using Authing.ApiClient.Domain.Model.Management.Users;
using Authing.ApiClient.Domain.Model.Management.Groups;
using Authing.ApiClient.Domain.Model.Management.Orgs;
using Authing.ApiClient.Domain.Model.Management.Roles;
using Authing.ApiClient.Domain.Model.Management.Department;
using Authing.ApiClient.Types;

namespace Authing.ApiClient.Interfaces.ManagementClient
{
    public interface IUsersManagementClient
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="createUserOption">选项</param>
        /// <returns></returns>
        Task<User> Create(CreateUserInput userInfo, CreateUserOption createUserOption = null);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <param name="updates">更新信息</param>
        /// <returns></returns>
        Task<User> Update(string userId, UpdateUserInput updates);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <param name="withCustomData">是否带用户自定义数据</param>
        /// <returns></returns>
        Task<User> Detail(string userId, bool withCustomData = false);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns></returns>
        Task<CommonMessage> Delete(string userId);

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="userIds">用户 ID 列表，多个 ID 以英文逗号分隔</param>
        /// <returns></returns>
        Task<CommonMessage> DeleteMany(IEnumerable<string> userIds);

        /// <summary>
        /// 通过 ID 列表批量获取用户信息
        /// </summary>
        /// <param name="userIds">用户 ID 列表</param>
        /// <returns></returns>
        Task<IEnumerable<User>> Batch(IEnumerable<string> userIds, BatchFetchUserTypes batchFetchUserType = BatchFetchUserTypes.ID);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="page">当前页数，默认为 1</param>
        /// <param name="limit">每页最大数量，默认为 10</param>
        /// <returns></returns>
        Task<PaginatedUsers> List(int page = 1, int limit = 10);

        /// <summary>
        /// 获取已归档用户列表
        /// </summary>
        /// <param name="page">当前页数，默认为 1</param>
        /// <param name="limit">每页最大数量，默认为 10</param>
        /// <returns></returns>
        Task<PaginatedUsers> ListArchivedUsers(int page = 1, int limit = 10);

        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="options">选项</param>
        /// <returns></returns>
        Task<bool?> Exists(ExistsOption options);

        /// <summary>
        /// 通过手机号、游戏、用户名查找用户
        /// </summary>
        /// <param name="FindUserOption">选项</param>
        /// <returns></returns>
        Task<User> Find(FindUserOption options);

        /// <summary>
        /// 模糊搜索用户
        /// </summary>
        /// <param name="query">关键字</param>
        /// <param name="SearchOption">选项</param>
        /// <returns></returns>
        Task<PaginatedUsers> Search(string query, SearchOption option = null);

        /// <summary>
        /// 刷新 access token
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns></returns>
        Task<RefreshToken> RefreshToken(string userId);

        /// <summary>
        /// 获取用户分组列表
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns></returns>
        Task<PaginatedGroups> ListGroups(string userId);

        /// <summary>
        /// 加入分组
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <param name="group">分组 ID</param>
        /// <returns></returns>
        Task<CommonMessage> AddGroup(string userId, string group);

        /// <summary>
        /// 退出分组
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <param name="group">分组 ID</param>
        /// <returns></returns>
        Task<CommonMessage> RemoveGroup(string userId, string group);

        /// <summary>
        /// 获取用户角色列表
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns></returns>
        Task<PaginatedRoles> ListRoles(string userId, string _namespace = null);

        /// <summary>
        /// 批量授权角色
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <param name="roles">用户角色 Code 列表</param>
        /// <returns></returns>
        Task<CommonMessage> AddRoles(string userId, IEnumerable<string> roles, string _namespace = null);

        /// <summary>
        /// 批量撤销用户角色
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <param name="roles">用户角色 Code 列表</param>
        /// <returns></returns>
        Task<CommonMessage> RemoveRoles(string userId, IEnumerable<string> roles, string _namespace = null);

        /// <summary>
        /// 获取用户所在组织机构
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns></returns>
        Task<PaginatedOrgs> ListOrgs(string userId);

        /// <summary>
        /// 获取用户所在部门
        /// </summary>
        /// <param name="userId">用户 ID</param>
        /// <returns></returns>
        Task<PaginatedDepartments> ListDepartment(string userId);
    }
}
