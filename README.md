# xml�ļ�תSqlsugarʵ����

## ��װȫ�ֹ���
```
dotnet tool install sugartool -g 

```

## �ڰ���Model.xml��ĿĿ¼��ִ��
```
sugartool

```


## Model.xml�ļ�ʾ��
```xml

<?xml version="1.0" encoding="utf-8"?>
<Tables xmlns:xs="http://www.w3.org/2001/XMLSchema-instance" xs:schemaLocation="https://newlifex.com https://newlifex.com/Model2022.xsd" NameSpace="Sqlsugar.Entity" ConnName="Paladin" Output="Entity" BaseClass="Entity" Version="11.1.2022.0523" Document="https://newlifex.com/xcode/model" xmlns="https://newlifex.com/Model2022.xsd">
   <Table Name="User" Description="�û����û��ʺ���Ϣ���������֤Ϊ���ģ�ӵ�ж��ֽ�ɫ���ɼ������⻧">
      <Columns>
        <Column Name="ID" DataType="Int32" Identity="True" PrimaryKey="True" Description="���" />
        <Column Name="Name" DataType="String" Master="True" Nullable="False" Description="���ơ���¼�û���" />
        <Column Name="Password" DataType="String" Length="200" Description="����" />
        <Column Name="DisplayName" DataType="String" Description="�ǳ�" />
        <Column Name="Sex" DataType="Int32" Description="�Ա�δ֪���С�Ů" Type="XCode.Membership.SexKinds" />
        <Column Name="Mail" DataType="String" ItemType="mail" Description="�ʼ���֧�ֵ�¼" />
        <Column Name="Mobile" DataType="String" ItemType="mobile" Description="�ֻ���֧�ֵ�¼" />
        <Column Name="Code" DataType="String" Description="���롣���֤��Ա������ȣ�֧�ֵ�¼" />
        <Column Name="AreaId" DataType="Int32" Map="XCode.Membership.Area@Id@Path@AreaPath" Description="������ʡ����" />
        <Column Name="Avatar" DataType="String" ItemType="image" Length="200" Description="ͷ��" />
        <Column Name="RoleID" DataType="Int32" Map="Role@Id@Name" DefaultValue="3" Description="��ɫ����Ҫ��ɫ" Category="��¼��Ϣ" />
        <Column Name="RoleIds" DataType="String" Length="200" Description="��ɫ�顣��Ҫ��ɫ����" Category="��¼��Ϣ" />
        <Column Name="DepartmentID" DataType="Int32" Map="Department@Id@Name" Description="���š���֯����" Category="��¼��Ϣ" />
        <Column Name="Online" DataType="Boolean" Description="����" Category="��¼��Ϣ" />
        <Column Name="Enable" DataType="Boolean" Description="����" Category="��¼��Ϣ" />
        <Column Name="Age" DataType="Int32" Description="���䡣����" />
        <Column Name="Birthday" DataType="DateTime" Description="���ա�����������" />
        <Column Name="Logins" DataType="Int32" Description="��¼����" Category="��¼��Ϣ" />
        <Column Name="LastLogin" DataType="DateTime" Description="����¼" Category="��¼��Ϣ" />
        <Column Name="LastLoginIP" DataType="String" Description="����¼IP" Category="��¼��Ϣ" />
        <Column Name="RegisterTime" DataType="DateTime" Description="ע��ʱ��" Category="��¼��Ϣ" />
        <Column Name="RegisterIP" DataType="String" Description="ע��IP" Category="��¼��Ϣ" />
        <Column Name="OnlineTime" DataType="Int32" ItemType="TimeSpan" Description="����ʱ�䡣�ۼ�������ʱ�䣬��λ��" Category="��¼��Ϣ" />
        <Column Name="Ex1" DataType="Int32" Description="��չ1" Category="��չ" />
        <Column Name="Ex2" DataType="Int32" Description="��չ2" Category="��չ" />
        <Column Name="Ex3" DataType="Double" Description="��չ3" Category="��չ" />
        <Column Name="Ex4" DataType="String" Description="��չ4" Category="��չ" />
        <Column Name="Ex5" DataType="String" Description="��չ5" Category="��չ" />
        <Column Name="Ex6" DataType="String" Description="��չ6" Attribute="XmlIgnore, ScriptIgnore, IgnoreDataMember" Category="��չ" />
        <Column Name="UpdateUser" DataType="String" Nullable="False" DefaultValue="''" Description="������" Model="False" Category="��չ" />
        <Column Name="UpdateUserID" DataType="Int32" Description="�����û�" Model="False" Category="��չ" />
        <Column Name="UpdateIP" DataType="String" Description="���µ�ַ" Model="False" Category="��չ" />
        <Column Name="UpdateTime" DataType="DateTime" Nullable="False" Description="����ʱ��" Model="False" Category="��չ" />
        <Column Name="Remark" DataType="String" Length="500" Description="��ע" Category="��չ" />
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


## ע��
��δ����Map����,�ȴ�����������