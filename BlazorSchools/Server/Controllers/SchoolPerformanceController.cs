﻿using BlazorSchools.Shared.Data.EnitityFramework;
using BlazorSchools.Shared.Data;
using BlazorSchools.Shared.Data.Sim;
using BlazorSchools.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorSchools.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolPerformanceController : ControllerBase
    {
        public string ErrorString { get; set; }

        private readonly IHttpClientFactory _clientFactory = null;
        private readonly ILogger<SchoolPerformanceController> _logger = null;
        private readonly SchoolsSqlDataService _sqlService = null;
        private readonly SchoolsSimDataService _simService = null;
        private readonly SchoolEFDataService _efService = null;
        private readonly CommonControllerSupport _support = null;
        private readonly IConfiguration _configuration = null;
        private readonly bool UseSim = false;
        private readonly bool UseEF = false;
        private readonly bool UseDapper = false;
        private readonly bool AllowEF = false;
        private readonly bool AllowDapper = false;
        private int Records = 0;
        private int DapperUpdatePerformance = 0;
        private int EFUpdatePerformance = 0;
        private int SimUpdatePerformance = 0;
        private readonly int MaxPage = 0;

        public SchoolPerformanceController(ILogger<SchoolPerformanceController> logger,
                                           IHttpClientFactory clientFactory,
                                           IConfiguration configuration,
                                           SchoolsSqlDataService sqlService,
                                           SchoolsSimDataService simService,
                                           SchoolEFDataService efService)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _sqlService = sqlService;
            _simService = simService;
            _efService = efService;
            _configuration = configuration;

            try
            {
                string useSIM = _configuration.GetValue<string>("UseSIM");
                if (useSIM == "1")
                    UseSim = true;

                string useEF = _configuration.GetValue<string>("UseEF");
                if (useEF == "1")
                    UseEF = true;

                string allowEF = _configuration.GetValue<string>("AllowEF");
                if (allowEF == "1")
                    AllowEF = true;

                string allowDapper = _configuration.GetValue<string>("AllowDapper");
                if (allowDapper == "1")
                    AllowDapper = true;

                if ((UseSim == false) && (UseEF == false) && (AllowDapper == true))
                    UseDapper = true;

                string maxPage = configuration.GetValue<string>("MaxPage");
                MaxPage = Convert.ToInt32(maxPage);
            }
            catch (Exception e)
            {
                logger.LogError("Exception loading configuration", e);
            }

            _support = new CommonControllerSupport();
        }

        [HttpGet]
        public async Task<Performance> Get()
        {
            Stopwatch stopWatch;
            Performance perf = new Performance
            {
                InitPerformance = 0,
                DapperPerformance = 0,
                EFPerformance = 0,
                JsonPerformance = 0,
                SimPerformance = 0,
                DapperPerformance2 = 0,
                EFPerformance2 = 0,
                JsonPerformance2 = 0,
                SimPerformance2 = 0,
                DapperUpdatePerformance = 0,
                EFUpdatePerformance = 0,
                SimUpdatePerformance = 0,
                Records = 0,
                MaxPage = MaxPage
            };

            if (UseSim == true)
                perf.UseSIM = 1;
            else
                perf.UseSIM = 0;

            if (UseEF == true)
                perf.UseEF = 1;
            else
                perf.UseEF = 0;

            if (UseDapper == true)
                perf.UseDapper = 1;
            else
                perf.UseDapper = 0;

            if (AllowEF == true)
                perf.AllowEF = 1;
            else
                perf.AllowEF = 0;

            if (AllowDapper == true)
                perf.AllowDapper = 1;
            else
                perf.AllowDapper = 0;

            try
            {
                _logger.LogInformation("Initialize");
                stopWatch = Stopwatch.StartNew();
                await Initialize();
                stopWatch.Stop();
                perf.InitPerformance = (int)stopWatch.ElapsedMilliseconds;
                _logger.LogInformation("Initialzie Performance is {perf}", perf.InitPerformance);

                perf.Records = Records;
                perf.DapperUpdatePerformance = DapperUpdatePerformance;
                perf.EFUpdatePerformance = EFUpdatePerformance;
                perf.SimUpdatePerformance = SimUpdatePerformance;

                _logger.LogInformation("Loading Json");
                stopWatch = Stopwatch.StartNew();
                Schools schoolList = await _support.GetJson(_clientFactory);
                stopWatch.Stop();
                perf.JsonPerformance = (int)stopWatch.ElapsedMilliseconds;
                _logger.LogInformation("Json Performance is {perf}", perf.JsonPerformance);

                if (AllowDapper == true)
                {
                    _logger.LogInformation("Loading Dapper Sql Database");
                    stopWatch = Stopwatch.StartNew();
                    schoolList = await _support.GetData(_sqlService, 0, 0);
                    stopWatch.Stop();
                    perf.DapperPerformance = (int)stopWatch.ElapsedMilliseconds;
                    _logger.LogInformation("Dapper Performance is {perf}", perf.DapperPerformance);
                }

                if (AllowEF == true)
                {
                    _logger.LogInformation("Loading Entity Framework Sql Database");
                    stopWatch = Stopwatch.StartNew();
                    schoolList = await _support.GetData(_efService, 0, 0);
                    stopWatch.Stop();
                    perf.EFPerformance = (int)stopWatch.ElapsedMilliseconds;
                    _logger.LogInformation("Entity Framework Performance is {perf}", perf.EFPerformance);
                }

                if (UseSim == true)
                {
                    _logger.LogInformation("Loading Simulated Database");
                    stopWatch = Stopwatch.StartNew();
                    schoolList = await _support.GetData(_simService, 0, 0);
                    stopWatch.Stop();
                    perf.SimPerformance = (int)stopWatch.ElapsedMilliseconds;
                    _logger.LogInformation("Simulated Performance is {perf}", perf.SimPerformance);
                }

                _logger.LogInformation("Loading Json");
                stopWatch = Stopwatch.StartNew();
                schoolList = await _support.GetJson(_clientFactory);
                stopWatch.Stop();
                perf.JsonPerformance2 = (int)stopWatch.ElapsedMilliseconds;
                _logger.LogInformation("Json Performance (2) is {perf}", perf.JsonPerformance2);

                if (AllowDapper == true)
                {
                    _logger.LogInformation("Loading Dapper Sql Database");
                    stopWatch = Stopwatch.StartNew();
                    schoolList = await _support.GetData(_sqlService, 0, 0);
                    stopWatch.Stop();
                    perf.DapperPerformance2 = (int)stopWatch.ElapsedMilliseconds;
                    _logger.LogInformation("Dapper Performance (2) is {perf}", perf.DapperPerformance2);
                }

                if (AllowEF == true)
                {
                    _logger.LogInformation("Loading Entity Framework Sql Database");
                    stopWatch = Stopwatch.StartNew();
                    schoolList = await _support.GetData(_efService, 0, 0);
                    stopWatch.Stop();
                    perf.EFPerformance2 = (int)stopWatch.ElapsedMilliseconds;
                    _logger.LogInformation("Entity Framework Performance (2) is {perf}", perf.EFPerformance2);
                }

                if (UseSim == true)
                {
                    _logger.LogInformation("Loading Simulated Database");
                    stopWatch = Stopwatch.StartNew();
                    schoolList = await _support.GetData(_simService, 0, 0);
                    stopWatch.Stop();
                    perf.SimPerformance2 = (int)stopWatch.ElapsedMilliseconds;
                    _logger.LogInformation("Simulated Performance (2) is {perf}", perf.SimPerformance);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Exception doing performance test", e);
            }

            return perf;
        }

        internal async Task Initialize()
        {
            Stopwatch stopWatch;

            // this routines loads data from Json and then stores them in updates dataservice
            _logger.LogInformation("Loading Json");
            Schools schoolList = await _support.GetJson(_clientFactory);
            ErrorString = _support.ErrorString;
            if ((ErrorString != null) && (ErrorString.Length > 0))
                _logger.LogError("Error loading Json");
            else
            {
                if (schoolList.schools != null)
                    Records = schoolList.schools.Length;

                if (AllowDapper == true)
                {
                    _logger.LogInformation("Updating Dapper Sql database");
                    stopWatch = Stopwatch.StartNew();
                    await _support.UpdateData(schoolList, _sqlService);
                    stopWatch.Stop();
                    DapperUpdatePerformance = (int)stopWatch.ElapsedMilliseconds;
                    _logger.LogInformation("Dapper Update Performance  is {perf}", DapperUpdatePerformance);
                    ErrorString = _support.ErrorString;
                    if ((ErrorString != null) && (ErrorString.Length > 0))
                        _logger.LogError("Error updating Dapper SQL Database");
                }

                if (AllowEF == true)
                {
                    _logger.LogInformation("Updating Entity Framework Sql database");
                    stopWatch = Stopwatch.StartNew();
                    await _support.UpdateData(schoolList, _efService);
                    stopWatch.Stop();
                    EFUpdatePerformance = (int)stopWatch.ElapsedMilliseconds;
                    _logger.LogInformation("Entity Framework Update Performance  is {perf}", EFUpdatePerformance);
                    ErrorString = _support.ErrorString;
                    if ((ErrorString != null) && (ErrorString.Length > 0))
                        _logger.LogError("Error updating Entity Framework SQL Database");
                }

                if (UseSim == true)
                {
                    _logger.LogInformation("Updating Simulated database");
                    stopWatch = Stopwatch.StartNew();
                    await _support.UpdateData(schoolList, _simService);
                    stopWatch.Stop();
                    SimUpdatePerformance = (int)stopWatch.ElapsedMilliseconds;
                    _logger.LogInformation("Simulated  Update Performance  is {perf}", SimUpdatePerformance);
                    ErrorString = _support.ErrorString;
                    if ((ErrorString != null) && (ErrorString.Length > 0))
                        _logger.LogError("Error updating Simulated Database");
                }
            }
        }
    }
}