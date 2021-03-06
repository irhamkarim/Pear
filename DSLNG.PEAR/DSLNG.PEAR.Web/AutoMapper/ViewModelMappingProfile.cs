﻿using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DSLNG.PEAR.Services.Common.PmsSummary;
using DSLNG.PEAR.Services.Interfaces;
using DSLNG.PEAR.Services.Requests.KpiAchievement;
using DSLNG.PEAR.Services.Requests.Measurement;
using DSLNG.PEAR.Services.Requests.PmsSummary;
using DSLNG.PEAR.Services.Responses.KpiAchievement;
using DSLNG.PEAR.Services.Responses.Level;
using DSLNG.PEAR.Services.Responses.Measurement;
using DSLNG.PEAR.Services.Responses.PmsSummary;
using DSLNG.PEAR.Services.Responses.Kpi;
using DSLNG.PEAR.Services.Requests.Kpi;
using DSLNG.PEAR.Web.ViewModels.Common;
using DSLNG.PEAR.Web.ViewModels.Common.PmsSummary;
using DSLNG.PEAR.Web.ViewModels.Kpi;
using DSLNG.PEAR.Services.Responses.Menu;
using DSLNG.PEAR.Services.Requests.Menu;
using DSLNG.PEAR.Web.ViewModels.KpiAchievement;
using DSLNG.PEAR.Web.ViewModels.Level;
using DSLNG.PEAR.Web.ViewModels.Measurement;
using DSLNG.PEAR.Web.ViewModels.Menu;
using DSLNG.PEAR.Services.Requests.Level;
using DSLNG.PEAR.Services.Requests.User;
using DSLNG.PEAR.Services.Responses.User;
using DSLNG.PEAR.Web.ViewModels.PmsConfig;
using DSLNG.PEAR.Web.ViewModels.PmsConfigDetails;
using DSLNG.PEAR.Web.ViewModels.PmsSummary;
using DSLNG.PEAR.Web.ViewModels.User;
using DSLNG.PEAR.Web.ViewModels.RoleGroup;
using DSLNG.PEAR.Services.Responses.RoleGroup;
using DSLNG.PEAR.Services.Requests.RoleGroup;
using DSLNG.PEAR.Web.ViewModels.Type;
using DSLNG.PEAR.Services.Responses.Type;
using DSLNG.PEAR.Services.Requests.Type;
using DSLNG.PEAR.Services.Responses.Pillar;
using DSLNG.PEAR.Services.Requests.Pillar;
using DSLNG.PEAR.Web.ViewModels.Pillar;
using DSLNG.PEAR.Web.ViewModels.Artifact;
using DSLNG.PEAR.Services.Requests.Artifact;
using System;
using EPeriodeType = DSLNG.PEAR.Data.Enums.PeriodeType;
using DSLNG.PEAR.Data.Enums;
using DSLNG.PEAR.Common.Extensions;
using DSLNG.PEAR.Services.Responses.Artifact;
using System.Linq;
using DSLNG.PEAR.Services.Responses.Group;
using DSLNG.PEAR.Services.Requests.Group;
using DSLNG.PEAR.Web.ViewModels.Group;
using DSLNG.PEAR.Services.Responses.Method;
using DSLNG.PEAR.Web.ViewModels.Method;
using DSLNG.PEAR.Services.Requests.Method;
using DSLNG.PEAR.Services.Requests.Periode;
using DSLNG.PEAR.Web.ViewModels.Periode;
using DSLNG.PEAR.Services.Responses.Periode;
using DSLNG.PEAR.Web.ViewModels.KpiTarget;
using DSLNG.PEAR.Services.Requests.KpiTarget;
using DSLNG.PEAR.Services.Requests.Conversion;
using DSLNG.PEAR.Services.Responses.Conversion;
using DSLNG.PEAR.Web.ViewModels.Conversion;
using DSLNG.PEAR.Services.Responses.KpiTarget;
using DSLNG.PEAR.Web.ViewModels.Template;
using DSLNG.PEAR.Services.Requests.Template;
using Kpi = DSLNG.PEAR.Web.ViewModels.KpiTarget.Kpi;
using DSLNG.PEAR.Services.Responses.Template;

namespace DSLNG.PEAR.Web.AutoMapper
{
    public class ViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            ConfigureCorporatePortofolio();
            ConfigurePmsSummary();
            ConfigureKpiTarget();
            ConfigureKpiAchievement();
            ConfigureTrafficLight();

            Mapper.CreateMap<Dropdown, SelectListItem>();
            Mapper.CreateMap<SearchKpiViewModel, GetKpiToSeriesRequest>();
            Mapper.CreateMap<GetKpiToSeriesResponse, KpiToSeriesViewModel>();
            Mapper.CreateMap<CreateKpiViewModel, CreateKpiRequest>();
            Mapper.CreateMap<DSLNG.PEAR.Web.ViewModels.Kpi.KpiRelationModel, DSLNG.PEAR.Services.Requests.Kpi.KpiRelationModel>();
            Mapper.CreateMap<GetKpiResponse, UpdateKpiViewModel>()
               .ForMember(k => k.LevelId, o => o.MapFrom(x => x.Level.Id))
               .ForMember(k => k.GroupId, o => o.MapFrom(x => x.Group.Id))
               .ForMember(k => k.RoleGroupId, o => o.MapFrom(x => x.RoleGroup.Id))
               .ForMember(k => k.MeasurementId, o => o.MapFrom(x => x.Measurement.Id))
               .ForMember(k => k.MethodId, o => o.MapFrom(x => x.Method.Id))
               .ForMember(k => k.TypeId, o => o.MapFrom(x => x.Type.Id))
               .ForMember(k => k.YtdFormulaValue, o => o.MapFrom(x => x.YtdFormula.ToString()))
               .ForMember(k => k.PeriodeValue, o => o.MapFrom(x => x.Periode.ToString()))
               .ForMember(k => k.RelationModels, o => o.MapFrom(x => x.RelationModels));
            Mapper.CreateMap<DSLNG.PEAR.Services.Responses.Kpi.KpiRelationModel, DSLNG.PEAR.Web.ViewModels.Kpi.KpiRelationModel>();
            Mapper.CreateMap<UpdateKpiViewModel, UpdateKpiRequest>();

            //Mapper.CreateMap<GetMenusResponse.Menu, MenuViewModel>();
            Mapper.CreateMap<CreateMenuViewModel, CreateMenuRequest>();
            Mapper.CreateMap<GetMenuResponse, UpdateMenuViewModel>()
                .ForMember(x => x.RoleGroupIds, o => o.MapFrom(k => k.RoleGroups.Select(x => x.Id).ToList()));
            Mapper.CreateMap<UpdateMenuViewModel, UpdateMenuRequest>();

            Mapper.CreateMap<CreateMeasurementViewModel, CreateMeasurementRequest>();
            Mapper.CreateMap<GetMeasurementResponse, UpdateMeasurementViewModel>();
            Mapper.CreateMap<UpdateMeasurementViewModel, UpdateMeasurementRequest>();
            Mapper.CreateMap<GetMeasurementsResponse.Measurement, MeasurementViewModel>();
            Mapper.CreateMap<GetMeasurementResponse, DSLNG.PEAR.Web.ViewModels.Kpi.Measurement>();

            Mapper.CreateMap<CreateLevelViewModel, CreateLevelRequest>();
            Mapper.CreateMap<GetLevelResponse, UpdateLevelViewModel>();
            Mapper.CreateMap<UpdateLevelViewModel, UpdateLevelRequest>();

            Mapper.CreateMap<CreateUserViewModel, CreateUserRequest>();
            Mapper.CreateMap<GetUserResponse, UpdateUserViewModel>();
            Mapper.CreateMap<UpdateUserViewModel, UpdateUserRequest>();
            Mapper.CreateMap<GetUsersResponse.User, UserViewModel>()
                .ForMember(x => x.RoleName, y => y.MapFrom(z => z.Role.Name));
            Mapper.CreateMap<UserLoginViewModel, LoginUserRequest>();

            Mapper.CreateMap<GetRoleGroupsResponse.RoleGroup, RoleGroupViewModel>();
            Mapper.CreateMap<CreateRoleGroupViewModel, CreateRoleGroupRequest>();
            Mapper.CreateMap<GetRoleGroupResponse, UpdateRoleGroupViewModel>()
                .ForMember(o => o.LevelId, p => p.MapFrom(k => k.Level.Id));
            Mapper.CreateMap<UpdateRoleGroupViewModel, UpdateRoleGroupRequest>();
            Mapper.CreateMap<GetRoleGroupResponse, DSLNG.PEAR.Web.ViewModels.Kpi.RoleGroup>();

            Mapper.CreateMap<GetTypeResponse, UpdateTypeViewModel>();
            Mapper.CreateMap<GetTypesResponse.Type, TypeViewModel>();
            Mapper.CreateMap<CreateTypeViewModel, CreateTypeRequest>();
            Mapper.CreateMap<UpdateTypeViewModel, UpdateTypeRequest>();
            Mapper.CreateMap<GetTypeResponse, DSLNG.PEAR.Web.ViewModels.Kpi.Type>();

            Mapper.CreateMap<CreatePillarViewModel, CreatePillarRequest>();
            Mapper.CreateMap<GetPillarResponse, UpdatePillarViewModel>();
            Mapper.CreateMap<UpdatePillarViewModel, UpdatePillarRequest>();
            Mapper.CreateMap<GetPillarsResponse, DSLNG.PEAR.Web.ViewModels.Kpi.Pillar>();

            Mapper.CreateMap<CreateMethodViewModel, CreateMethodRequest>();
            Mapper.CreateMap<GetMethodRequest, UpdateMethodViewModel>();
            Mapper.CreateMap<UpdateMethodRequest, UpdateMethodViewModel>();
            Mapper.CreateMap<GetMethodResponse, UpdateMethodViewModel>();
            Mapper.CreateMap<UpdateMethodViewModel, UpdateMethodRequest>();

            Mapper.CreateMap<GetArtifactResponse, ArtifactDesignerViewModel>();
            Mapper.CreateMap<GetArtifactResponse, BarChartViewModel>();
            Mapper.CreateMap<GetArtifactResponse.SeriesResponse, BarChartViewModel.SeriesViewModel>();
            Mapper.CreateMap<GetArtifactResponse.StackResponse, BarChartViewModel.StackViewModel>();
            Mapper.CreateMap<GetArtifactResponse, LineChartViewModel>();
            Mapper.CreateMap<GetArtifactResponse.SeriesResponse, LineChartViewModel.SeriesViewModel>();
            Mapper.CreateMap<GetArtifactResponse, AreaChartViewModel>();
            Mapper.CreateMap<GetArtifactResponse.SeriesResponse, AreaChartViewModel.SeriesViewModel>();
            Mapper.CreateMap<GetArtifactResponse, SpeedometerChartViewModel>()
                .ForMember(x => x.Series, o => o.MapFrom(s => s.Series.FirstOrDefault()));
            Mapper.CreateMap<GetArtifactResponse.SeriesResponse, SpeedometerChartViewModel.SeriesViewModel>();
            Mapper.CreateMap<GetArtifactResponse.PlotResponse, SpeedometerChartViewModel.PlotBand>();

            //cartesian preview
            Mapper.CreateMap<ArtifactDesignerViewModel, GetCartesianChartDataRequest>()
                .ForMember(x => x.PeriodeType, o => o.MapFrom(s => Enum.Parse(typeof(EPeriodeType), s.PeriodeType)))
                .ForMember(x => x.RangeFilter, o => o.MapFrom(s => Enum.Parse(typeof(RangeFilter), s.RangeFilter)))
                .ForMember(x => x.ValueAxis, o => o.MapFrom(s => Enum.Parse(typeof(ValueAxis), s.ValueAxis)))
                .ForMember(x => x.Start, y => y.MapFrom(z => z.StartAfterParsed))
                .ForMember(x => x.End, y => y.MapFrom(z => z.EndAfterParsed)); ;

            //bar chart mapping
            Mapper.CreateMap<BarChartViewModel, GetCartesianChartDataRequest>();
            Mapper.CreateMap<BarChartViewModel.SeriesViewModel, GetCartesianChartDataRequest.SeriesRequest>();
            Mapper.CreateMap<BarChartViewModel.StackViewModel, GetCartesianChartDataRequest.StackRequest>();
            Mapper.CreateMap<GetCartesianChartDataResponse.SeriesResponse, BarChartDataViewModel.SeriesViewModel>();
            Mapper.CreateMap<BarChartViewModel, CreateArtifactRequest>()
              .ForMember(x => x.Series, o => o.MapFrom(s => s.Series.MapTo<CreateArtifactRequest.SeriesRequest>()));
            Mapper.CreateMap<BarChartViewModel.SeriesViewModel, CreateArtifactRequest.SeriesRequest>()
               .ForMember(x => x.Stacks, o => o.MapFrom(s => s.Stacks.MapTo<CreateArtifactRequest.StackRequest>()));
            Mapper.CreateMap<BarChartViewModel.StackViewModel, CreateArtifactRequest.StackRequest>();
            Mapper.CreateMap<BarChartViewModel, UpdateArtifactRequest>()
          .ForMember(x => x.Series, o => o.MapFrom(s => s.Series.MapTo<UpdateArtifactRequest.SeriesRequest>()));
            Mapper.CreateMap<BarChartViewModel.SeriesViewModel, UpdateArtifactRequest.SeriesRequest>()
               .ForMember(x => x.Stacks, o => o.MapFrom(s => s.Stacks.MapTo<UpdateArtifactRequest.StackRequest>()));
            Mapper.CreateMap<BarChartViewModel.StackViewModel, UpdateArtifactRequest.StackRequest>();

            //line chart mapping
            Mapper.CreateMap<LineChartViewModel, GetCartesianChartDataRequest>();
            Mapper.CreateMap<LineChartViewModel.SeriesViewModel, GetCartesianChartDataRequest.SeriesRequest>();
            Mapper.CreateMap<GetCartesianChartDataResponse.SeriesResponse, LineChartDataViewModel.SeriesViewModel>();
            Mapper.CreateMap<LineChartViewModel, CreateArtifactRequest>()
               .ForMember(x => x.Series, o => o.MapFrom(s => s.Series.MapTo<CreateArtifactRequest.SeriesRequest>()));
            Mapper.CreateMap<LineChartViewModel.SeriesViewModel, CreateArtifactRequest.SeriesRequest>();
            Mapper.CreateMap<LineChartViewModel, UpdateArtifactRequest>()
              .ForMember(x => x.Series, o => o.MapFrom(s => s.Series.MapTo<UpdateArtifactRequest.SeriesRequest>()));
            Mapper.CreateMap<LineChartViewModel.SeriesViewModel, UpdateArtifactRequest.SeriesRequest>();

            //area chart mapping
            Mapper.CreateMap<AreaChartViewModel, GetCartesianChartDataRequest>();
            Mapper.CreateMap<AreaChartViewModel.SeriesViewModel, GetCartesianChartDataRequest.SeriesRequest>();
            Mapper.CreateMap<GetCartesianChartDataResponse.SeriesResponse, AreaChartDataViewModel.SeriesViewModel>();
            Mapper.CreateMap<AreaChartViewModel, CreateArtifactRequest>();
            Mapper.CreateMap<AreaChartViewModel.SeriesViewModel, CreateArtifactRequest.SeriesRequest>();
            Mapper.CreateMap<AreaChartViewModel, UpdateArtifactRequest>();
            Mapper.CreateMap<AreaChartViewModel.SeriesViewModel, UpdateArtifactRequest.SeriesRequest>();

            //speedometer chart mapping
            Mapper.CreateMap<ArtifactDesignerViewModel, GetSpeedometerChartDataRequest>()
                .ForMember(x => x.Start, y => y.MapFrom(z => z.StartAfterParsed))
                .ForMember(x => x.End, y => y.MapFrom(z => z.EndAfterParsed));
            Mapper.CreateMap<SpeedometerChartViewModel, GetSpeedometerChartDataRequest>();
            Mapper.CreateMap<SpeedometerChartViewModel.SeriesViewModel, GetSpeedometerChartDataRequest.SeriesRequest>();
            Mapper.CreateMap<SpeedometerChartViewModel.PlotBand, GetSpeedometerChartDataRequest.PlotBandRequest>();
            Mapper.CreateMap<GetSpeedometerChartDataResponse.SeriesResponse, SpeedometerChartDataViewModel.SeriesViewModel>()
                .ForMember(x => x.data, o => o.MapFrom(s => new List<double> { s.data }));
            Mapper.CreateMap<GetSpeedometerChartDataResponse.PlotBandResponse, SpeedometerChartDataViewModel.PlotBandViewModel>();
            Mapper.CreateMap<SpeedometerChartViewModel, CreateArtifactRequest>()
            .ForMember(x => x.Series, o => o.MapFrom(s => new List<CreateArtifactRequest.SeriesRequest> { s.Series.MapTo<CreateArtifactRequest.SeriesRequest>() }))
            .ForMember(x => x.Plots, o => o.MapFrom(s => s.PlotBands.MapTo<CreateArtifactRequest.PlotRequest>()));
            Mapper.CreateMap<SpeedometerChartViewModel.SeriesViewModel, CreateArtifactRequest.SeriesRequest>();
            Mapper.CreateMap<SpeedometerChartViewModel.PlotBand, CreateArtifactRequest.PlotRequest>();
            Mapper.CreateMap<SpeedometerChartViewModel, UpdateArtifactRequest>()
            .ForMember(x => x.Series, o => o.MapFrom(s => new List<UpdateArtifactRequest.SeriesRequest> { s.Series.MapTo<UpdateArtifactRequest.SeriesRequest>() }))
            .ForMember(x => x.Plots, o => o.MapFrom(s => s.PlotBands.MapTo<UpdateArtifactRequest.PlotRequest>()));
            Mapper.CreateMap<SpeedometerChartViewModel.SeriesViewModel, UpdateArtifactRequest.SeriesRequest>();
            Mapper.CreateMap<SpeedometerChartViewModel.PlotBand, UpdateArtifactRequest.PlotRequest>();

            //tabular mapping
            Mapper.CreateMap<TabularViewModel, CreateArtifactRequest>();
            Mapper.CreateMap<TabularViewModel.RowViewModel, CreateArtifactRequest.RowRequest>()
                .ForMember(x => x.PeriodeType, o => o.MapFrom(s => Enum.Parse(typeof(EPeriodeType), s.PeriodeType)))
                .ForMember(x => x.RangeFilter, o => o.MapFrom(s => Enum.Parse(typeof(RangeFilter), s.RangeFilter)));
            Mapper.CreateMap<ArtifactDesignerViewModel, GetTabularDataRequest>();
            Mapper.CreateMap<TabularViewModel, GetTabularDataRequest>();
            Mapper.CreateMap<TabularViewModel.RowViewModel, GetTabularDataRequest.RowRequest>();
            Mapper.CreateMap<GetTabularDataResponse, TabularDataViewModel>();
            Mapper.CreateMap<GetTabularDataResponse.RowResponse, TabularDataViewModel.RowViewModel>();
            Mapper.CreateMap<GetArtifactResponse, TabularViewModel>();
            Mapper.CreateMap<GetArtifactResponse.RowResponse, TabularViewModel.RowViewModel>();

            //tank mapping
            Mapper.CreateMap<TankViewModel, CreateArtifactRequest.TankRequest>();
            Mapper.CreateMap<ArtifactDesignerViewModel, GetTankDataRequest>()
                .ForMember(x => x.Start, y => y.MapFrom(z => z.StartAfterParsed))
                .ForMember(x => x.End, y => y.MapFrom(z => z.EndAfterParsed)); ;
            Mapper.CreateMap<TankViewModel, GetTankDataRequest.TankRequest>();
            Mapper.CreateMap<GetTankDataResponse, TankDataViewModel>();
            Mapper.CreateMap<TankViewModel, UpdateArtifactRequest>();
            Mapper.CreateMap<TankViewModel, UpdateArtifactRequest.TankRequest>();
            Mapper.CreateMap<TabularViewModel, UpdateArtifactRequest>();
            Mapper.CreateMap<TabularViewModel.RowViewModel, UpdateArtifactRequest.RowRequest>();
            
            
       
            //Mapper.CreateMap<BarChartViewModel.SeriesViewModel, GetSeriesRequest.Series>()
            //    .ForMember(x => x.Stacks, o => o.MapFrom(s => s.Stacks.MapTo<GetSeriesRequest.Stack>()));
            //Mapper.CreateMap<BarChartViewModel.StackViewModel, GetSeriesRequest.Stack>();
            //Mapper.CreateMap<GetSeriesResponse.SeriesResponse, BarChartDataViewModel.SeriesViewModel>();

            Mapper.CreateMap<GetGroupResponse, DSLNG.PEAR.Web.ViewModels.Kpi.Group>();

            Mapper.CreateMap<GetMethodResponse, DSLNG.PEAR.Web.ViewModels.Kpi.Method>();

            Mapper.CreateMap<BarChartViewModel.SeriesViewModel, GetCartesianChartDataRequest.SeriesRequest>()
                .ForMember(x => x.Stacks, o => o.MapFrom(s => s.Stacks.MapTo<GetCartesianChartDataRequest.StackRequest>()));
            Mapper.CreateMap<BarChartViewModel.StackViewModel, GetCartesianChartDataRequest.StackRequest>();
            Mapper.CreateMap<CreateGroupViewModel, CreateGroupRequest>();
            Mapper.CreateMap<GetGroupResponse, UpdateGroupViewModel>();
            Mapper.CreateMap<UpdateGroupViewModel, UpdateGroupRequest>();

            Mapper.CreateMap<CreatePeriodeViewModel, CreatePeriodeRequest>();
            Mapper.CreateMap<GetPeriodeResponse, UpdatePeriodeViewModel>();
            Mapper.CreateMap<UpdatePeriodeViewModel, UpdatePeriodeRequest>();

            Mapper.CreateMap<ArtifactDesignerViewModel, CreateArtifactRequest>()
                .ForMember(x => x.PeriodeType, o => o.MapFrom(s => Enum.Parse(typeof(EPeriodeType), s.PeriodeType)))
                .ForMember(x => x.RangeFilter, o => o.MapFrom(s => Enum.Parse(typeof(RangeFilter), s.RangeFilter)))
                .ForMember(x => x.ValueAxis, o => o.MapFrom(s => Enum.Parse(typeof(ValueAxis), s.ValueAxis)))
                .ForMember(x => x.Start, y => y.MapFrom(z => z.StartAfterParsed))
                .ForMember(x => x.End, y => y.MapFrom(z => z.EndAfterParsed));

            Mapper.CreateMap<ArtifactDesignerViewModel, UpdateArtifactRequest>()
              .ForMember(x => x.PeriodeType, o => o.MapFrom(s => Enum.Parse(typeof(EPeriodeType), s.PeriodeType)))
              .ForMember(x => x.RangeFilter, o => o.MapFrom(s => Enum.Parse(typeof(RangeFilter), s.RangeFilter)))
              .ForMember(x => x.ValueAxis, o => o.MapFrom(s => Enum.Parse(typeof(ValueAxis), s.ValueAxis)))
              .ForMember(x => x.Start, y => y.MapFrom(z => z.StartAfterParsed))
            .ForMember(x => x.End, y => y.MapFrom(z => z.EndAfterParsed));

            Mapper.CreateMap<GetArtifactResponse, GetCartesianChartDataRequest>()
                .ForMember(x => x.Series, o => o.MapFrom(s => s.Series.MapTo<GetCartesianChartDataRequest.SeriesRequest>()));
            Mapper.CreateMap<GetArtifactResponse.SeriesResponse, GetCartesianChartDataRequest.SeriesRequest>()
                .ForMember(x => x.Stacks, o => o.MapFrom(s => s.Stacks.MapTo<GetCartesianChartDataRequest.StackRequest>()));
            Mapper.CreateMap<GetArtifactResponse.StackResponse, GetCartesianChartDataRequest.StackRequest>();

            Mapper.CreateMap<GetArtifactResponse, GetSpeedometerChartDataRequest>()
             .ForMember(x => x.PlotBands, o => o.MapFrom(s => s.PlotBands.MapTo<GetSpeedometerChartDataRequest.PlotBandRequest>()))
             .ForMember(x => x.Series, o => o.MapFrom(s => s.Series[0]));
            Mapper.CreateMap<GetArtifactResponse.PlotResponse, GetSpeedometerChartDataRequest.PlotBandRequest>();
            Mapper.CreateMap<GetArtifactResponse.SeriesResponse, GetSpeedometerChartDataRequest.SeriesRequest>();

            Mapper.CreateMap<GetArtifactResponse, GetTabularDataRequest>();
            Mapper.CreateMap<GetArtifactResponse.RowResponse, GetTabularDataRequest.RowRequest>();
            Mapper.CreateMap<GetArtifactResponse, GetTankDataRequest>();
            Mapper.CreateMap<GetArtifactResponse.TankResponse, GetTankDataRequest.TankRequest>();
            Mapper.CreateMap<GetArtifactResponse.TankResponse, TankViewModel>();
            Mapper.CreateMap<GetArtifactResponse, TankViewModel>();
            //Mapper.CreateMap<GetArtifactResponse., GetSpeedometerChartDataRequest.PlotBandRequest>();
            //Mapper.CreateMap<GetArtifactResponse.SeriesResponse, GetSpeedometerChartDataRequest.SeriesRequest>();

            Mapper.CreateMap<CreateConversionViewModel, CreateConversionRequest>();
            Mapper.CreateMap<GetConversionResponse, UpdateConversionViewModel>()
                .ForMember(x => x.MeasurementFrom, o => o.MapFrom(k => k.From.Id))
                .ForMember(x => x.MeasurementTo, o => o.MapFrom(k => k.To.Id));
            Mapper.CreateMap<UpdateConversionViewModel, UpdateConversionRequest>();

            Mapper.CreateMap<TemplateViewModel, CreateTemplateRequest>();
            Mapper.CreateMap<TemplateViewModel.RowViewModel, CreateTemplateRequest.RowRequest>();
            Mapper.CreateMap<TemplateViewModel.ColumnViewModel, CreateTemplateRequest.ColumnRequest>();

            Mapper.CreateMap<TemplateViewModel, UpdateTemplateRequest>();
            Mapper.CreateMap<TemplateViewModel.RowViewModel, UpdateTemplateRequest.RowRequest>();
            Mapper.CreateMap<TemplateViewModel.ColumnViewModel, UpdateTemplateRequest.ColumnRequest>();

            Mapper.CreateMap<GetTemplateResponse, TemplateViewModel>();
            Mapper.CreateMap<GetTemplateResponse.RowResponse, TemplateViewModel.RowViewModel>();
            Mapper.CreateMap<GetTemplateResponse.ColumnResponse, TemplateViewModel.ColumnViewModel>();
            base.Configure();
        }

        private void ConfigureTrafficLight()
        {
            Mapper.CreateMap<ArtifactDesignerViewModel, GetTrafficLightChartDataRequest>()
                .ForMember(x => x.Start, y => y.MapFrom(z => z.StartAfterParsed))
                .ForMember(x => x.End, y => y.MapFrom(z => z.EndAfterParsed));

            Mapper.CreateMap<TrafficLightChartViewModel, GetTrafficLightChartDataRequest>();
            Mapper.CreateMap<TrafficLightChartViewModel.SeriesViewModel, GetTrafficLightChartDataRequest.SeriesRequest>();
            Mapper.CreateMap<TrafficLightChartViewModel.PlotBand, GetTrafficLightChartDataRequest.PlotBandRequest>();
            Mapper.CreateMap<GetTrafficLightChartDataResponse.SeriesResponse, TrafficLightChartDataViewModel.SeriesViewModel>()
                .ForMember(x => x.data, o => o.MapFrom(s => new List<double> { s.data }));
            Mapper.CreateMap<GetTrafficLightChartDataResponse.PlotBandResponse, TrafficLightChartDataViewModel.PlotBandViewModel>();
            Mapper.CreateMap<TrafficLightChartViewModel, CreateArtifactRequest>()
            .ForMember(x => x.Series, o => o.MapFrom(s => new List<CreateArtifactRequest.SeriesRequest> { s.Series.MapTo<CreateArtifactRequest.SeriesRequest>() }))
            .ForMember(x => x.Plots, o => o.MapFrom(s => s.PlotBands.MapTo<CreateArtifactRequest.PlotRequest>()));
            Mapper.CreateMap<TrafficLightChartViewModel.SeriesViewModel, CreateArtifactRequest.SeriesRequest>();
            Mapper.CreateMap<TrafficLightChartViewModel.PlotBand, CreateArtifactRequest.PlotRequest>();
            Mapper.CreateMap<TrafficLightChartViewModel, UpdateArtifactRequest>()
            .ForMember(x => x.Series, o => o.MapFrom(s => new List<UpdateArtifactRequest.SeriesRequest> { s.Series.MapTo<UpdateArtifactRequest.SeriesRequest>() }))
            .ForMember(x => x.Plots, o => o.MapFrom(s => s.PlotBands.MapTo<UpdateArtifactRequest.PlotRequest>()));
            Mapper.CreateMap<TrafficLightChartViewModel.SeriesViewModel, UpdateArtifactRequest.SeriesRequest>();
            Mapper.CreateMap<TrafficLightChartViewModel.PlotBand, UpdateArtifactRequest.PlotRequest>();

            Mapper.CreateMap<GetArtifactResponse, GetTrafficLightChartDataRequest>()
             .ForMember(x => x.PlotBands, o => o.MapFrom(s => s.PlotBands.MapTo<GetTrafficLightChartDataRequest.PlotBandRequest>()))
             .ForMember(x => x.Series, o => o.MapFrom(s => s.Series[0]));
            Mapper.CreateMap<GetArtifactResponse.PlotResponse, GetTrafficLightChartDataRequest.PlotBandRequest>();
            Mapper.CreateMap<GetArtifactResponse.SeriesResponse, GetTrafficLightChartDataRequest.SeriesRequest>();

            Mapper.CreateMap<GetArtifactResponse, TrafficLightChartViewModel>()
                .ForMember(x => x.Series, o => o.MapFrom(s => s.Series.FirstOrDefault()));
            Mapper.CreateMap<GetArtifactResponse.SeriesResponse, TrafficLightChartViewModel.SeriesViewModel>();
            Mapper.CreateMap<GetArtifactResponse.PlotResponse, TrafficLightChartViewModel.PlotBand>();
        }

        private void ConfigureCorporatePortofolio()
        {
            Mapper.CreateMap<GetPmsSummaryListResponse.PmsSummary, PmsSummaryConfigurationViewModel.CorporatePortofolio>();
            Mapper.CreateMap<GetPmsSummaryConfigurationResponse.PmsConfig, PmsSummaryDetailsViewModel.PmsConfig>();
            Mapper.CreateMap<GetPmsSummaryConfigurationResponse.PmsConfigDetails, PmsSummaryDetailsViewModel.PmsConfigDetails>()
                .ForMember(x => x.KpiId, y => y.MapFrom(z => z.Kpi.Id))
                .ForMember(x => x.KpiName, y => y.MapFrom(z => z.Kpi.Name))
                .ForMember(x => x.KpiMeasurement, y => y.MapFrom(z => z.Kpi.Measurement))
                .ForMember(x => x.ScoringType, y => y.MapFrom(z => z.ScoringType.ToString()));

            Mapper.CreateMap<GetPmsSummaryConfigurationResponse, PmsSummaryDetailsViewModel>()
                  .ForMember(x => x.Kpis, y => y.MapFrom(z => z.Kpis.Select(a => new SelectListItem
                      {
                          Text = a.Name,
                          Value = a.Id.ToString()
                      })))
                  .ForMember(x => x.Pillars, y => y.MapFrom(z => z.Pillars.Select(a => new SelectListItem
                      {
                          Text = a.Name,
                          Value = a.Id.ToString()
                      })));



            Mapper.CreateMap<GetScoreIndicatorsResponse, ScoreIndicatorDetailsViewModel>();
            Mapper.CreateMap<ScoreIndicator, ScoreIndicatorViewModel>();

            Mapper.CreateMap<ScoreIndicatorViewModel, ScoreIndicator>();
            Mapper.CreateMap<ScoreIndicator, ScoreIndicatorViewModel>();


        }

        private void ConfigurePmsSummary()
        {
            Mapper.CreateMap<CreatePmsSummaryViewModel, CreatePmsSummaryRequest>()
                .ForMember(x => x.ScoreIndicators, o => o.MapFrom(s => s.ScoreIndicators.Where(x => x.Id > 0 && !string.IsNullOrEmpty(x.Color) && !string.IsNullOrEmpty(x.Expression))));
            Mapper.CreateMap<GetPmsSummaryResponse, UpdatePmsSummaryViewModel>();
            Mapper.CreateMap<UpdatePmsSummaryViewModel, UpdatePmsSummaryRequest>()
                .ForMember(x => x.ScoreIndicators, o => o.MapFrom(s => s.ScoreIndicators.Where(x => x.Id > 0 && !string.IsNullOrEmpty(x.Color) && !string.IsNullOrEmpty(x.Expression))));

            Mapper.CreateMap<GetPmsSummaryReportResponse.KpiData, PmsSummaryViewModel>();
            Mapper.CreateMap<GetPmsDetailsResponse, PmsReportDetailsViewModel>();
            Mapper.CreateMap<GetPmsDetailsResponse.KpiAchievment, PmsReportDetailsViewModel.KpiAchievment>();
            Mapper.CreateMap<GetPmsDetailsResponse.KpiRelation, PmsReportDetailsViewModel.KpiRelation>();
            Mapper.CreateMap<CreatePmsConfigViewModel, CreatePmsConfigRequest>()
                .ForMember(x => x.ScoreIndicators, o => o.MapFrom(s => s.ScoreIndicators.Where(x => x.Id > 0 && !string.IsNullOrEmpty(x.Color) && !string.IsNullOrEmpty(x.Expression))));
            Mapper.CreateMap<GetPmsDetailsResponse.Group, PmsReportDetailsViewModel.Group>();
            ConfigurePmsConfig();
            ConfigurePmsConfigDetails();
        }

        private void ConfigurePmsConfig()
        {
            Mapper.CreateMap<GetPmsConfigResponse, UpdatePmsConfigViewModel>();
            Mapper.CreateMap<UpdatePmsConfigViewModel, UpdatePmsConfigRequest>()
                .ForMember(x => x.ScoreIndicators, o => o.MapFrom(s => s.ScoreIndicators.Where(x => x.Id > 0 && !string.IsNullOrEmpty(x.Color) && !string.IsNullOrEmpty(x.Expression))));
        }

        private void ConfigurePmsConfigDetails()
        {
            Mapper.CreateMap<CreatePmsConfigDetailsViewModel, CreatePmsConfigDetailsRequest>()
                .ForMember(x => x.ScoreIndicators, o => o.MapFrom(s => s.ScoreIndicators.Where(x => x.Id > 0 && !string.IsNullOrEmpty(x.Color) && !string.IsNullOrEmpty(x.Expression))));
            Mapper.CreateMap<GetPmsConfigDetailsResponse, UpdatePmsConfigDetailsViewModel>();
            Mapper.CreateMap<UpdatePmsConfigDetailsViewModel, UpdatePmsConfigDetailsRequest>()
                .ForMember(x => x.ScoreIndicators, o => o.MapFrom(s => s.ScoreIndicators.Where(x => x.Id > 0 && !string.IsNullOrEmpty(x.Color) && !string.IsNullOrEmpty(x.Expression))));
        }

        private void ConfigureKpiTarget()
        {
            Mapper.CreateMap<GetPmsConfigsResponse.Kpi, Kpi>()
                .ForMember(k => k.Unit, o => o.MapFrom(k => k.Measurement.Name));

            Mapper.CreateMap<GetKpiTargetResponse, UpdateKpiTargetViewModel>();
            Mapper.CreateMap<GetKpiTargetResponse.Kpi, UpdateKpiTargetViewModel.Kpi>();
            Mapper.CreateMap<GetKpiTargetResponse.KpiTarget, UpdateKpiTargetViewModel.KpiTarget>();
            Mapper.CreateMap<GetKpiTargetResponse.Pillar, UpdateKpiTargetViewModel.Pillar>();

            Mapper.CreateMap<UpdateKpiTargetViewModel, UpdateKpiTargetRequest>();
            Mapper.CreateMap<UpdateKpiTargetViewModel.Kpi, UpdateKpiTargetRequest.Kpi>();
            Mapper.CreateMap<UpdateKpiTargetViewModel.KpiTarget, UpdateKpiTargetRequest.KpiTarget>();
            Mapper.CreateMap<UpdateKpiTargetViewModel.Pillar, UpdateKpiTargetRequest.Pillar>();

            Mapper.CreateMap<AllKpiTargetsResponse, IndexKpiTargetViewModel>();
            Mapper.CreateMap<AllKpiTargetsResponse.Kpi, IndexKpiTargetViewModel.Kpi>();
            Mapper.CreateMap<AllKpiTargetsResponse.RoleGroup, IndexKpiTargetViewModel.RoleGroup>();

            Mapper.CreateMap<GetKpiTargetsConfigurationResponse, ConfigurationKpiTargetsViewModel>();
            Mapper.CreateMap<GetKpiTargetsConfigurationResponse.Kpi, ConfigurationKpiTargetsViewModel.Kpi>();
            Mapper.CreateMap<GetKpiTargetsConfigurationResponse.KpiTarget, ConfigurationKpiTargetsViewModel.KpiTarget>();

            Mapper.CreateMap<KpiTargetItem, CreateKpiTargetRequest>();
            Mapper.CreateMap<KpiTargetItem, UpdateKpiTargetItemRequest>()
                .ForMember(x => x.PeriodeType, o => o.MapFrom(x => (DSLNG.PEAR.Data.Enums.PeriodeType)x.PeriodeType));
        }

        private void ConfigureKpiAchievement()
        {
            Mapper.CreateMap<GetKpiAchievementsResponse, UpdateKpiAchievementsViewModel>();
            Mapper.CreateMap<GetKpiAchievementsResponse.Kpi, UpdateKpiAchievementsViewModel.Kpi>();
            Mapper.CreateMap<GetKpiAchievementsResponse.KpiAchievement, UpdateKpiAchievementsViewModel.KpiAchievement>();
            Mapper.CreateMap<GetKpiAchievementsResponse.Pillar, UpdateKpiAchievementsViewModel.Pillar>();

            Mapper.CreateMap<UpdateKpiAchievementsViewModel, UpdateKpiAchievementsRequest>();
            Mapper.CreateMap<UpdateKpiAchievementsViewModel.Kpi, UpdateKpiAchievementsRequest.Kpi>();
            Mapper.CreateMap<UpdateKpiAchievementsViewModel.KpiAchievement, UpdateKpiAchievementsRequest.KpiAchievement>();
            Mapper.CreateMap<UpdateKpiAchievementsViewModel.Pillar, UpdateKpiAchievementsRequest.Pillar>();

            Mapper.CreateMap<AllKpiAchievementsResponse, IndexKpiAchievementViewModel>();
            Mapper.CreateMap<AllKpiAchievementsResponse.Kpi, IndexKpiAchievementViewModel.Kpi>();
            Mapper.CreateMap<AllKpiAchievementsResponse.RoleGroup, IndexKpiAchievementViewModel.RoleGroup>();

            Mapper.CreateMap<GetKpiAchievementsConfigurationResponse, ConfigurationKpiAchievementsViewModel>();
            Mapper.CreateMap<GetKpiAchievementsConfigurationResponse.Kpi, ConfigurationKpiAchievementsViewModel.Kpi>();
            Mapper.CreateMap<GetKpiAchievementsConfigurationResponse.KpiAchievement, ConfigurationKpiAchievementsViewModel.KpiAchievement>();

            Mapper.CreateMap<UpdateKpiAchievementsViewModel.KpiAchievementItem, UpdateKpiAchievementItemRequest>()
                .ForMember(x => x.PeriodeType, o => o.MapFrom(x => (DSLNG.PEAR.Data.Enums.PeriodeType)x.PeriodeType));

        }
    }
}