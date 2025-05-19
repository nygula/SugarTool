# xml文件转Sqlsugar实体类

## 安装全局工具
```
dotnet tool install sugartool -g 

```

## 在包含Model.xml项目目录下执行
```
sugartool

```


## Model.xml文件示例
```xml

<?xml version="1.0" encoding="utf-8"?>
<Tables xmlns:xs="http://www.w3.org/2001/XMLSchema-instance" xs:schemaLocation="https://newlifex.com https://newlifex.com/Model2022.xsd" NameSpace="Sqlsugar.Entity" ConnName="Paladin" Output="Entity" BaseClass="Entity" Version="11.1.2022.0523" Document="https://newlifex.com/xcode/model" xmlns="https://newlifex.com/Model2022.xsd">
   <Table Name="User" Description="用户。用户帐号信息，以身份验证为中心，拥有多种角色，可加入多个租户">
      <Columns>
        <Column Name="ID" DataType="Int32" Identity="True" PrimaryKey="True" Description="编号" />
        <Column Name="Name" DataType="String" Master="True" Nullable="False" Description="名称。登录用户名" />
        <Column Name="Password" DataType="String" Length="200" Description="密码" />
        <Column Name="DisplayName" DataType="String" Description="昵称" />
        <Column Name="Sex" DataType="Int32" Description="性别。未知、男、女" Type="XCode.Membership.SexKinds" />
        <Column Name="Mail" DataType="String" ItemType="mail" Description="邮件。支持登录" />
        <Column Name="Mobile" DataType="String" ItemType="mobile" Description="手机。支持登录" />
        <Column Name="Code" DataType="String" Description="代码。身份证、员工编码等，支持登录" />
        <Column Name="AreaId" DataType="Int32" Map="XCode.Membership.Area@Id@Path@AreaPath" Description="地区。省市区" />
        <Column Name="Avatar" DataType="String" ItemType="image" Length="200" Description="头像" />
        <Column Name="RoleID" DataType="Int32" Map="Role@Id@Name" DefaultValue="3" Description="角色。主要角色" Category="登录信息" />
        <Column Name="RoleIds" DataType="String" Length="200" Description="角色组。次要角色集合" Category="登录信息" />
        <Column Name="DepartmentID" DataType="Int32" Map="Department@Id@Name" Description="部门。组织机构" Category="登录信息" />
        <Column Name="Online" DataType="Boolean" Description="在线" Category="登录信息" />
        <Column Name="Enable" DataType="Boolean" Description="启用" Category="登录信息" />
        <Column Name="Age" DataType="Int32" Description="年龄。周岁" />
        <Column Name="Birthday" DataType="DateTime" Description="生日。公历年月日" />
        <Column Name="Logins" DataType="Int32" Description="登录次数" Category="登录信息" />
        <Column Name="LastLogin" DataType="DateTime" Description="最后登录" Category="登录信息" />
        <Column Name="LastLoginIP" DataType="String" Description="最后登录IP" Category="登录信息" />
        <Column Name="RegisterTime" DataType="DateTime" Description="注册时间" Category="登录信息" />
        <Column Name="RegisterIP" DataType="String" Description="注册IP" Category="登录信息" />
        <Column Name="OnlineTime" DataType="Int32" ItemType="TimeSpan" Description="在线时间。累计在线总时间，单位秒" Category="登录信息" />
        <Column Name="Ex1" DataType="Int32" Description="扩展1" Category="扩展" />
        <Column Name="Ex2" DataType="Int32" Description="扩展2" Category="扩展" />
        <Column Name="Ex3" DataType="Double" Description="扩展3" Category="扩展" />
        <Column Name="Ex4" DataType="String" Description="扩展4" Category="扩展" />
        <Column Name="Ex5" DataType="String" Description="扩展5" Category="扩展" />
        <Column Name="Ex6" DataType="String" Description="扩展6" Attribute="XmlIgnore, ScriptIgnore, IgnoreDataMember" Category="扩展" />
        <Column Name="UpdateUser" DataType="String" Nullable="False" DefaultValue="''" Description="更新者" Model="False" Category="扩展" />
        <Column Name="UpdateUserID" DataType="Int32" Description="更新用户" Model="False" Category="扩展" />
        <Column Name="UpdateIP" DataType="String" Description="更新地址" Model="False" Category="扩展" />
        <Column Name="UpdateTime" DataType="DateTime" Nullable="False" Description="更新时间" Model="False" Category="扩展" />
        <Column Name="Remark" DataType="String" Length="500" Description="备注" Category="扩展" />
      </Columns>
      <Indexes>
        <Index Columns="Name" Unique="True" />
        <Index Columns="Mail" />
        <Index Columns="Mobile" />
        <Index Columns="Code" />
        <Index Columns="RoleID" />
        <Index Columns="UpdateTime" />
      </Indexes>
    </Table>
  </Tables>

```


## 注意
暂未处理Map属性,等待大佬们完善