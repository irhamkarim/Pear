﻿using DSLNG.PEAR.Services.Requests.KpiTarget;
using DSLNG.PEAR.Services.Responses.KpiTarget;

namespace DSLNG.PEAR.Services.Interfaces
{
    public interface IKpiTargetService
    {
        CreateKpiTargetResponse Create(CreateKpiTargetRequest request);
        CreateKpiTargetsResponse Creates(CreateKpiTargetsRequest request);
        GetPmsConfigsResponse GetPmsConfigs(GetPmsConfigsRequest request);
        GetKpiTargetsResponse GetKpiTargets(GetKpiTargetsRequest request);
        GetKpiTargetResponse GetKpiTarget(GetKpiTargetRequest request);
        UpdateKpiTargetResponse UpdateKpiTarget(UpdateKpiTargetRequest request);
        UpdateKpiTargetItemResponse UpdateKpiTargetItem(UpdateKpiTargetItemRequest request);
        GetKpiTargetsConfigurationResponse GetKpiTargetsConfiguration(GetKpiTargetsConfigurationRequest request);
        AllKpiTargetsResponse GetAllKpiTargets();
    }
}
