﻿namespace Wallee.ESign.RemoteApi
{
    public enum EnterpriseAuthResponseErrorCode:int
    {
        企业信息校验未通过 = 1201001,
        请核实入参格式是否正确 = 30500000,
        认证失败企业信息校验未通过 = 30500001,
        缺少参数 = 30500100,
        参数错误 = 30500101,
        格式校验不通过 = 30500116,
        订单余额不足 = 30503107,
        信息比对不通过 = 30504001,
        数据源查询失败 = 30504002,
        法定代表人与经办人姓名不一致 = 30502020
    }
}