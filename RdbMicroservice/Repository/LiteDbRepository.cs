using LiteDB;
using Microsoft.Extensions.Configuration;
using rdbMicroservice.Models;
using rdbMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdbMicroservice.Repository
{
    public class LiteDbRepository
    {
        private readonly LiteCollection<SPoint> _points;
        private readonly LiteCollection<STable> _tables;
        protected RdbService _rdbService;
        protected SubscribePointDictionary _subscribePointDictionary;

        public LiteDbRepository(IConfiguration config, IRdbService rdbService, ISubscribePointDictionary subscribePointDictionary)
        {

            var db = new LiteDatabase(config.GetConnectionString("SubscriptionDb"));


            _points = db.GetCollection<SPoint>("points");
            _points.EnsureIndex(x => x.PID, true);
            //_points.Delete(x => true);
            _tables = db.GetCollection<STable>("tables");
            _tables.EnsureIndex(x => x.Name, true);
            //_tables.Delete(x => true);
            //AddTestData();

            _rdbService = (RdbService)rdbService;
            _subscribePointDictionary = (SubscribePointDictionary)subscribePointDictionary;


        }
        private void AddTestData()
        {
            if (_points == null || _points.Count() == 0)
            {
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0001" });
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0002" });
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0003" });
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0004" });
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0005" });
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0006" });
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0007" });
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0008" });
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0009" });
                _points.Insert(new SPoint { PID = "r_s01_t10_a_0010" });

            }
            if (_tables == null || _tables.Count() == 0)
            {
                //add data
                //_tables.Insert(new STable { Name = "r_s01_t1_a" });
                //_tables.Insert(new STable { Name = "r_s01_t2_a" });
                //_tables.Insert(new STable { Name = "r_s01_t3_a" });
                //_tables.Insert(new STable { Name = "r_s01_t4_a" });
                //_tables.Insert(new STable { Name = "r_s01_t5_a" });
                //_tables.Insert(new STable { Name = "r_s01_t6_a" });
                //_tables.Insert(new STable { Name = "r_s01_t7_a" });
                //_tables.Insert(new STable { Name = "r_s01_t8_a" });
                //_tables.Insert(new STable { Name = "r_s01_t9_a" });
                //_tables.Insert(new STable { Name = "r_s01_t10_a" });

                //_tables.Insert(new STable { Name = "r_s02_t1_a" });
                //_tables.Insert(new STable { Name = "r_s02_t2_a" });
                //_tables.Insert(new STable { Name = "r_s02_t3_a" });
                //_tables.Insert(new STable { Name = "r_s02_t4_a" });
                //_tables.Insert(new STable { Name = "r_s02_t5_a" });
                //_tables.Insert(new STable { Name = "r_s02_t6_a" });
                //_tables.Insert(new STable { Name = "r_s02_t7_a" });
                //_tables.Insert(new STable { Name = "r_s02_t8_a" });
                //_tables.Insert(new STable { Name = "r_s02_t9_a" });
                //_tables.Insert(new STable { Name = "r_s02_t10_a" });

                //_tables.Insert(new STable { Name = "r_s03_t1_a" });
                //_tables.Insert(new STable { Name = "r_s03_t2_a" });
                //_tables.Insert(new STable { Name = "r_s03_t3_a" });
                //_tables.Insert(new STable { Name = "r_s03_t4_a" });
                //_tables.Insert(new STable { Name = "r_s03_t5_a" });
                //_tables.Insert(new STable { Name = "r_s03_t6_a" });
                //_tables.Insert(new STable { Name = "r_s03_t7_a" });
                //_tables.Insert(new STable { Name = "r_s03_t8_a" });
                //_tables.Insert(new STable { Name = "r_s03_t9_a" });
                //_tables.Insert(new STable { Name = "r_s03_t10_a" });

                //_tables.Insert(new STable { Name = "r_s04_t1_a" });
                //_tables.Insert(new STable { Name = "r_s04_t2_a" });
                //_tables.Insert(new STable { Name = "r_s04_t3_a" });
                //_tables.Insert(new STable { Name = "r_s04_t4_a" });
                //_tables.Insert(new STable { Name = "r_s04_t5_a" });
                //_tables.Insert(new STable { Name = "r_s04_t6_a" });
                //_tables.Insert(new STable { Name = "r_s04_t7_a" });
                //_tables.Insert(new STable { Name = "r_s04_t8_a" });
                //_tables.Insert(new STable { Name = "r_s04_t9_a" });
                //_tables.Insert(new STable { Name = "r_s04_t10_a" });

                //_tables.Insert(new STable { Name = "r_s05_t1_a" });
                //_tables.Insert(new STable { Name = "r_s05_t2_a" });
                //_tables.Insert(new STable { Name = "r_s05_t3_a" });
                //_tables.Insert(new STable { Name = "r_s05_t4_a" });
                //_tables.Insert(new STable { Name = "r_s05_t5_a" });
                //_tables.Insert(new STable { Name = "r_s05_t6_a" });
                //_tables.Insert(new STable { Name = "r_s05_t7_a" });
                //_tables.Insert(new STable { Name = "r_s05_t8_a" });
                //_tables.Insert(new STable { Name = "r_s05_t9_a" });
                //_tables.Insert(new STable { Name = "r_s05_t10_a" });

                //_tables.Insert(new STable { Name = "r_s06_t1_a" });
                //_tables.Insert(new STable { Name = "r_s06_t2_a" });
                //_tables.Insert(new STable { Name = "r_s06_t3_a" });
                //_tables.Insert(new STable { Name = "r_s06_t4_a" });
                //_tables.Insert(new STable { Name = "r_s06_t5_a" });
                //_tables.Insert(new STable { Name = "r_s06_t6_a" });
                //_tables.Insert(new STable { Name = "r_s06_t7_a" });
                //_tables.Insert(new STable { Name = "r_s06_t8_a" });
                //_tables.Insert(new STable { Name = "r_s06_t9_a" });
                //_tables.Insert(new STable { Name = "r_s06_t10_a" });

                //_tables.Insert(new STable { Name = "r_s07_t1_a" });
                //_tables.Insert(new STable { Name = "r_s07_t2_a" });
                //_tables.Insert(new STable { Name = "r_s07_t3_a" });
                //_tables.Insert(new STable { Name = "r_s07_t4_a" });
                //_tables.Insert(new STable { Name = "r_s07_t5_a" });
                //_tables.Insert(new STable { Name = "r_s07_t6_a" });
                //_tables.Insert(new STable { Name = "r_s07_t7_a" });
                //_tables.Insert(new STable { Name = "r_s07_t8_a" });
                //_tables.Insert(new STable { Name = "r_s07_t9_a" });
                //_tables.Insert(new STable { Name = "r_s07_t10_a" });

                //_tables.Insert(new STable { Name = "r_s08_t1_a" });
                //_tables.Insert(new STable { Name = "r_s08_t2_a" });
                //_tables.Insert(new STable { Name = "r_s08_t3_a" });
                //_tables.Insert(new STable { Name = "r_s08_t4_a" });
                //_tables.Insert(new STable { Name = "r_s08_t5_a" });
                //_tables.Insert(new STable { Name = "r_s08_t6_a" });
                //_tables.Insert(new STable { Name = "r_s08_t7_a" });
                //_tables.Insert(new STable { Name = "r_s08_t8_a" });
                //_tables.Insert(new STable { Name = "r_s08_t9_a" });
                //_tables.Insert(new STable { Name = "r_s08_t10_a" });

                //_tables.Insert(new STable { Name = "r_s09_t1_a" });
                //_tables.Insert(new STable { Name = "r_s09_t2_a" });
                //_tables.Insert(new STable { Name = "r_s09_t3_a" });
                //_tables.Insert(new STable { Name = "r_s09_t4_a" });
                //_tables.Insert(new STable { Name = "r_s09_t5_a" });
                //_tables.Insert(new STable { Name = "r_s09_t6_a" });
                //_tables.Insert(new STable { Name = "r_s09_t7_a" });
                //_tables.Insert(new STable { Name = "r_s09_t8_a" });
                //_tables.Insert(new STable { Name = "r_s09_t9_a" });
                //_tables.Insert(new STable { Name = "r_s09_t10_a" });

                //_tables.Insert(new STable { Name = "r_s10_t1_a" });
                //_tables.Insert(new STable { Name = "r_s10_t2_a" });
                //_tables.Insert(new STable { Name = "r_s10_t3_a" });
                //_tables.Insert(new STable { Name = "r_s10_t4_a" });
                //_tables.Insert(new STable { Name = "r_s10_t5_a" });
                //_tables.Insert(new STable { Name = "r_s10_t6_a" });
                //_tables.Insert(new STable { Name = "r_s10_t7_a" });
                //_tables.Insert(new STable { Name = "r_s10_t8_a" });
                //_tables.Insert(new STable { Name = "r_s10_t9_a" });
                //_tables.Insert(new STable { Name = "r_s10_t10_a" });

                //_tables.Insert(new STable { Name = "r_s11_t1_a" });
                //_tables.Insert(new STable { Name = "r_s11_t2_a" });
                //_tables.Insert(new STable { Name = "r_s11_t3_a" });
                //_tables.Insert(new STable { Name = "r_s11_t4_a" });
                //_tables.Insert(new STable { Name = "r_s11_t5_a" });
                //_tables.Insert(new STable { Name = "r_s11_t6_a" });
                //_tables.Insert(new STable { Name = "r_s11_t7_a" });
                //_tables.Insert(new STable { Name = "r_s11_t8_a" });
                //_tables.Insert(new STable { Name = "r_s11_t9_a" });
                //_tables.Insert(new STable { Name = "r_s11_t10_a" });

                //_tables.Insert(new STable { Name = "r_s12_t1_a" });
                //_tables.Insert(new STable { Name = "r_s12_t2_a" });
                //_tables.Insert(new STable { Name = "r_s12_t3_a" });
                //_tables.Insert(new STable { Name = "r_s12_t4_a" });
                //_tables.Insert(new STable { Name = "r_s12_t5_a" });
                //_tables.Insert(new STable { Name = "r_s12_t6_a" });
                //_tables.Insert(new STable { Name = "r_s12_t7_a" });
                //_tables.Insert(new STable { Name = "r_s12_t8_a" });
                //_tables.Insert(new STable { Name = "r_s12_t9_a" });
                //_tables.Insert(new STable { Name = "r_s12_t10_a" });

                //_tables.Insert(new STable { Name = "r_s13_t1_a" });
                //_tables.Insert(new STable { Name = "r_s13_t2_a" });
                //_tables.Insert(new STable { Name = "r_s13_t3_a" });
                //_tables.Insert(new STable { Name = "r_s13_t4_a" });
                //_tables.Insert(new STable { Name = "r_s13_t5_a" });
                //_tables.Insert(new STable { Name = "r_s13_t6_a" });
                //_tables.Insert(new STable { Name = "r_s13_t7_a" });
                //_tables.Insert(new STable { Name = "r_s13_t8_a" });
                //_tables.Insert(new STable { Name = "r_s13_t9_a" });
                //_tables.Insert(new STable { Name = "r_s13_t10_a" });

                //_tables.Insert(new STable { Name = "r_s14_t1_a" });
                //_tables.Insert(new STable { Name = "r_s14_t2_a" });
                //_tables.Insert(new STable { Name = "r_s14_t3_a" });
                //_tables.Insert(new STable { Name = "r_s14_t4_a" });
                //_tables.Insert(new STable { Name = "r_s14_t5_a" });
                //_tables.Insert(new STable { Name = "r_s14_t6_a" });
                //_tables.Insert(new STable { Name = "r_s14_t7_a" });
                //_tables.Insert(new STable { Name = "r_s14_t8_a" });
                //_tables.Insert(new STable { Name = "r_s14_t9_a" });
                //_tables.Insert(new STable { Name = "r_s14_t10_a" });

                //_tables.Insert(new STable { Name = "r_s15_t1_a" });
                //_tables.Insert(new STable { Name = "r_s15_t2_a" });
                //_tables.Insert(new STable { Name = "r_s15_t3_a" });
                //_tables.Insert(new STable { Name = "r_s15_t4_a" });
                //_tables.Insert(new STable { Name = "r_s15_t5_a" });
                //_tables.Insert(new STable { Name = "r_s15_t6_a" });
                //_tables.Insert(new STable { Name = "r_s15_t7_a" });
                //_tables.Insert(new STable { Name = "r_s15_t8_a" });
                //_tables.Insert(new STable { Name = "r_s15_t9_a" });
                //_tables.Insert(new STable { Name = "r_s15_t10_a" });

                //_tables.Insert(new STable { Name = "r_s16_t1_a" });
                //_tables.Insert(new STable { Name = "r_s16_t2_a" });
                //_tables.Insert(new STable { Name = "r_s16_t3_a" });
                //_tables.Insert(new STable { Name = "r_s16_t4_a" });
                //_tables.Insert(new STable { Name = "r_s16_t5_a" });
                //_tables.Insert(new STable { Name = "r_s16_t6_a" });
                //_tables.Insert(new STable { Name = "r_s16_t7_a" });
                //_tables.Insert(new STable { Name = "r_s16_t8_a" });
                //_tables.Insert(new STable { Name = "r_s16_t9_a" });
                //_tables.Insert(new STable { Name = "r_s16_t10_a" });

                //_tables.Insert(new STable { Name = "r_s17_t1_a" });
                //_tables.Insert(new STable { Name = "r_s17_t2_a" });
                //_tables.Insert(new STable { Name = "r_s17_t3_a" });
                //_tables.Insert(new STable { Name = "r_s17_t4_a" });
                //_tables.Insert(new STable { Name = "r_s17_t5_a" });
                //_tables.Insert(new STable { Name = "r_s17_t6_a" });
                //_tables.Insert(new STable { Name = "r_s17_t7_a" });
                //_tables.Insert(new STable { Name = "r_s17_t8_a" });
                //_tables.Insert(new STable { Name = "r_s17_t9_a" });
                //_tables.Insert(new STable { Name = "r_s17_t10_a" });

                //_tables.Insert(new STable { Name = "r_s18_t1_a" });
                //_tables.Insert(new STable { Name = "r_s18_t2_a" });
                //_tables.Insert(new STable { Name = "r_s18_t3_a" });
                //_tables.Insert(new STable { Name = "r_s18_t4_a" });
                //_tables.Insert(new STable { Name = "r_s18_t5_a" });
                //_tables.Insert(new STable { Name = "r_s18_t6_a" });
                //_tables.Insert(new STable { Name = "r_s18_t7_a" });
                //_tables.Insert(new STable { Name = "r_s18_t8_a" });
                //_tables.Insert(new STable { Name = "r_s18_t9_a" });
                //_tables.Insert(new STable { Name = "r_s18_t10_a" });

                //_tables.Insert(new STable { Name = "r_s19_t1_a" });
                //_tables.Insert(new STable { Name = "r_s19_t2_a" });
                //_tables.Insert(new STable { Name = "r_s19_t3_a" });
                //_tables.Insert(new STable { Name = "r_s19_t4_a" });
                //_tables.Insert(new STable { Name = "r_s19_t5_a" });
                //_tables.Insert(new STable { Name = "r_s19_t6_a" });
                //_tables.Insert(new STable { Name = "r_s19_t7_a" });
                //_tables.Insert(new STable { Name = "r_s19_t8_a" });
                //_tables.Insert(new STable { Name = "r_s19_t9_a" });
                //_tables.Insert(new STable { Name = "r_s19_t10_a" });

                //_tables.Insert(new STable { Name = "r_s20_t1_a" });
                //_tables.Insert(new STable { Name = "r_s20_t2_a" });
                //_tables.Insert(new STable { Name = "r_s20_t3_a" });
                //_tables.Insert(new STable { Name = "r_s20_t4_a" });
                //_tables.Insert(new STable { Name = "r_s20_t5_a" });
                //_tables.Insert(new STable { Name = "r_s20_t6_a" });
                //_tables.Insert(new STable { Name = "r_s20_t7_a" });
                //_tables.Insert(new STable { Name = "r_s20_t8_a" });
                //_tables.Insert(new STable { Name = "r_s20_t9_a" });
                //_tables.Insert(new STable { Name = "r_s20_t10_a" });

                //_tables.Insert(new STable { Name = "r_s21_t1_a" });
                //_tables.Insert(new STable { Name = "r_s21_t2_a" });
                //_tables.Insert(new STable { Name = "r_s21_t3_a" });
                //_tables.Insert(new STable { Name = "r_s21_t4_a" });
                //_tables.Insert(new STable { Name = "r_s21_t5_a" });
                //_tables.Insert(new STable { Name = "r_s21_t6_a" });
                //_tables.Insert(new STable { Name = "r_s21_t7_a" });
                //_tables.Insert(new STable { Name = "r_s21_t8_a" });
                //_tables.Insert(new STable { Name = "r_s21_t9_a" });
                //_tables.Insert(new STable { Name = "r_s21_t10_a" });

                //_tables.Insert(new STable { Name = "r_s22_t1_a" });
                //_tables.Insert(new STable { Name = "r_s22_t2_a" });
                //_tables.Insert(new STable { Name = "r_s22_t3_a" });
                //_tables.Insert(new STable { Name = "r_s22_t4_a" });
                //_tables.Insert(new STable { Name = "r_s22_t5_a" });
                //_tables.Insert(new STable { Name = "r_s22_t6_a" });
                //_tables.Insert(new STable { Name = "r_s22_t7_a" });
                //_tables.Insert(new STable { Name = "r_s22_t8_a" });
                //_tables.Insert(new STable { Name = "r_s22_t9_a" });
                //_tables.Insert(new STable { Name = "r_s22_t10_a" });

                //_tables.Insert(new STable { Name = "r_s23_t1_a" });
                //_tables.Insert(new STable { Name = "r_s23_t2_a" });
                //_tables.Insert(new STable { Name = "r_s23_t3_a" });
                //_tables.Insert(new STable { Name = "r_s23_t4_a" });
                //_tables.Insert(new STable { Name = "r_s23_t5_a" });
                //_tables.Insert(new STable { Name = "r_s23_t6_a" });
                //_tables.Insert(new STable { Name = "r_s23_t7_a" });
                //_tables.Insert(new STable { Name = "r_s23_t8_a" });
                //_tables.Insert(new STable { Name = "r_s23_t9_a" });
                //_tables.Insert(new STable { Name = "r_s23_t10_a" });

                //_tables.Insert(new STable { Name = "r_s24_t1_a" });
                //_tables.Insert(new STable { Name = "r_s24_t2_a" });
                //_tables.Insert(new STable { Name = "r_s24_t3_a" });
                //_tables.Insert(new STable { Name = "r_s24_t4_a" });
                //_tables.Insert(new STable { Name = "r_s24_t5_a" });
                //_tables.Insert(new STable { Name = "r_s24_t6_a" });
                //_tables.Insert(new STable { Name = "r_s24_t7_a" });
                //_tables.Insert(new STable { Name = "r_s24_t8_a" });
                //_tables.Insert(new STable { Name = "r_s24_t9_a" });
                //_tables.Insert(new STable { Name = "r_s24_t10_a" });

                //_tables.Insert(new STable { Name = "r_s25_t1_a" });
                //_tables.Insert(new STable { Name = "r_s25_t2_a" });
                //_tables.Insert(new STable { Name = "r_s25_t3_a" });
                //_tables.Insert(new STable { Name = "r_s25_t4_a" });
                //_tables.Insert(new STable { Name = "r_s25_t5_a" });
                //_tables.Insert(new STable { Name = "r_s25_t6_a" });
                //_tables.Insert(new STable { Name = "r_s25_t7_a" });
                //_tables.Insert(new STable { Name = "r_s25_t8_a" });
                //_tables.Insert(new STable { Name = "r_s25_t9_a" });
                //_tables.Insert(new STable { Name = "r_s25_t10_a" });

                //_tables.Insert(new STable { Name = "r_s26_t1_a" });
                //_tables.Insert(new STable { Name = "r_s26_t2_a" });
                //_tables.Insert(new STable { Name = "r_s26_t3_a" });
                //_tables.Insert(new STable { Name = "r_s26_t4_a" });
                //_tables.Insert(new STable { Name = "r_s26_t5_a" });
                //_tables.Insert(new STable { Name = "r_s26_t6_a" });
                //_tables.Insert(new STable { Name = "r_s26_t7_a" });
                //_tables.Insert(new STable { Name = "r_s26_t8_a" });
                //_tables.Insert(new STable { Name = "r_s26_t9_a" });
                //_tables.Insert(new STable { Name = "r_s26_t10_a" });

                //_tables.Insert(new STable { Name = "r_s27_t1_a" });
                //_tables.Insert(new STable { Name = "r_s27_t2_a" });
                //_tables.Insert(new STable { Name = "r_s27_t3_a" });
                //_tables.Insert(new STable { Name = "r_s27_t4_a" });
                //_tables.Insert(new STable { Name = "r_s27_t5_a" });
                //_tables.Insert(new STable { Name = "r_s27_t6_a" });
                //_tables.Insert(new STable { Name = "r_s27_t7_a" });
                //_tables.Insert(new STable { Name = "r_s27_t8_a" });
                //_tables.Insert(new STable { Name = "r_s27_t9_a" });

                //_tables.Insert(new STable { Name = "r_s28_t1_a" });
                //_tables.Insert(new STable { Name = "r_s28_t2_a" });
                //_tables.Insert(new STable { Name = "r_s28_t3_a" });
                //_tables.Insert(new STable { Name = "r_s28_t4_a" });
                //_tables.Insert(new STable { Name = "r_s28_t5_a" });
                //_tables.Insert(new STable { Name = "r_s28_t6_a" });
                //_tables.Insert(new STable { Name = "r_s28_t7_a" });
                //_tables.Insert(new STable { Name = "r_s28_t8_a" });
                //_tables.Insert(new STable { Name = "r_s28_t9_a" });
                //_tables.Insert(new STable { Name = "r_s28_t10_a" });

                //_tables.Insert(new STable { Name = "r_s29_t1_a" });
                //_tables.Insert(new STable { Name = "r_s29_t2_a" });
                //_tables.Insert(new STable { Name = "r_s29_t3_a" });
                //_tables.Insert(new STable { Name = "r_s29_t4_a" });
                //_tables.Insert(new STable { Name = "r_s29_t5_a" });
                //_tables.Insert(new STable { Name = "r_s29_t6_a" });
                //_tables.Insert(new STable { Name = "r_s29_t7_a" });
                //_tables.Insert(new STable { Name = "r_s29_t8_a" });
                //_tables.Insert(new STable { Name = "r_s29_t9_a" });
                //_tables.Insert(new STable { Name = "r_s29_t10_a" });

                //_tables.Insert(new STable { Name = "r_s30_t1_a" });
                //_tables.Insert(new STable { Name = "r_s30_t2_a" });
                //_tables.Insert(new STable { Name = "r_s30_t3_a" });
                //_tables.Insert(new STable { Name = "r_s30_t4_a" });
                //_tables.Insert(new STable { Name = "r_s30_t5_a" });
                //_tables.Insert(new STable { Name = "r_s30_t6_a" });
                //_tables.Insert(new STable { Name = "r_s30_t7_a" });
                //_tables.Insert(new STable { Name = "r_s30_t8_a" });
                //_tables.Insert(new STable { Name = "r_s30_t9_a" });
                //_tables.Insert(new STable { Name = "r_s30_t10_a" });

                //_tables.Insert(new STable { Name = "r_s31_t1_a" });
                //_tables.Insert(new STable { Name = "r_s31_t2_a" });
                //_tables.Insert(new STable { Name = "r_s31_t3_a" });
                //_tables.Insert(new STable { Name = "r_s31_t4_a" });
                //_tables.Insert(new STable { Name = "r_s31_t5_a" });
                //_tables.Insert(new STable { Name = "r_s31_t6_a" });
                //_tables.Insert(new STable { Name = "r_s31_t7_a" });
                //_tables.Insert(new STable { Name = "r_s31_t8_a" });
                //_tables.Insert(new STable { Name = "r_s31_t9_a" });
                //_tables.Insert(new STable { Name = "r_s31_t10_a" });

                //_tables.Insert(new STable { Name = "r_s32_t1_a" });
                //_tables.Insert(new STable { Name = "r_s32_t2_a" });
                //_tables.Insert(new STable { Name = "r_s32_t3_a" });
                //_tables.Insert(new STable { Name = "r_s32_t4_a" });
                //_tables.Insert(new STable { Name = "r_s32_t5_a" });
                //_tables.Insert(new STable { Name = "r_s32_t6_a" });
                //_tables.Insert(new STable { Name = "r_s32_t7_a" });
                //_tables.Insert(new STable { Name = "r_s32_t8_a" });
                //_tables.Insert(new STable { Name = "r_s32_t9_a" });
                //_tables.Insert(new STable { Name = "r_s32_t10_a" });

                //_tables.Insert(new STable { Name = "r_s33_t1_a" });
                //_tables.Insert(new STable { Name = "r_s33_t2_a" });
                //_tables.Insert(new STable { Name = "r_s33_t3_a" });
                //_tables.Insert(new STable { Name = "r_s33_t4_a" });
                //_tables.Insert(new STable { Name = "r_s33_t5_a" });
                //_tables.Insert(new STable { Name = "r_s33_t6_a" });
                //_tables.Insert(new STable { Name = "r_s33_t7_a" });
                //_tables.Insert(new STable { Name = "r_s33_t8_a" });
                //_tables.Insert(new STable { Name = "r_s33_t9_a" });
                //_tables.Insert(new STable { Name = "r_s33_t10_a" });

                //_tables.Insert(new STable { Name = "r_s34_t1_a" });
                //_tables.Insert(new STable { Name = "r_s34_t2_a" });
                //_tables.Insert(new STable { Name = "r_s34_t3_a" });
                //_tables.Insert(new STable { Name = "r_s34_t4_a" });
                //_tables.Insert(new STable { Name = "r_s34_t5_a" });
                //_tables.Insert(new STable { Name = "r_s34_t6_a" });
                //_tables.Insert(new STable { Name = "r_s34_t7_a" });
                //_tables.Insert(new STable { Name = "r_s34_t8_a" });
                //_tables.Insert(new STable { Name = "r_s34_t9_a" });
                //_tables.Insert(new STable { Name = "r_s34_t10_a" });

                //_tables.Insert(new STable { Name = "r_s35_t1_a" });
                //_tables.Insert(new STable { Name = "r_s35_t2_a" });
                //_tables.Insert(new STable { Name = "r_s35_t3_a" });
                //_tables.Insert(new STable { Name = "r_s35_t4_a" });
                //_tables.Insert(new STable { Name = "r_s35_t5_a" });
                //_tables.Insert(new STable { Name = "r_s35_t6_a" });
                //_tables.Insert(new STable { Name = "r_s35_t7_a" });
                //_tables.Insert(new STable { Name = "r_s35_t8_a" });
                //_tables.Insert(new STable { Name = "r_s35_t9_a" });
                //_tables.Insert(new STable { Name = "r_s35_t10_a" });

                //_tables.Insert(new STable { Name = "r_s36_t1_a" });
                //_tables.Insert(new STable { Name = "r_s36_t2_a" });
                //_tables.Insert(new STable { Name = "r_s36_t3_a" });
                //_tables.Insert(new STable { Name = "r_s36_t4_a" });
                //_tables.Insert(new STable { Name = "r_s36_t5_a" });
                //_tables.Insert(new STable { Name = "r_s36_t6_a" });
                //_tables.Insert(new STable { Name = "r_s36_t7_a" });
                //_tables.Insert(new STable { Name = "r_s36_t8_a" });
                //_tables.Insert(new STable { Name = "r_s36_t9_a" });
                //_tables.Insert(new STable { Name = "r_s36_t10_a" });

                //_tables.Insert(new STable { Name = "r_s37_t1_a" });
                //_tables.Insert(new STable { Name = "r_s37_t2_a" });
                //_tables.Insert(new STable { Name = "r_s37_t3_a" });
                //_tables.Insert(new STable { Name = "r_s37_t4_a" });
                //_tables.Insert(new STable { Name = "r_s37_t5_a" });
                //_tables.Insert(new STable { Name = "r_s37_t6_a" });
                //_tables.Insert(new STable { Name = "r_s37_t7_a" });
                //_tables.Insert(new STable { Name = "r_s37_t8_a" });
                //_tables.Insert(new STable { Name = "r_s37_t9_a" });
                //_tables.Insert(new STable { Name = "r_s37_t10_a" });

                //_tables.Insert(new STable { Name = "r_s38_t1_a" });
                //_tables.Insert(new STable { Name = "r_s38_t2_a" });
                //_tables.Insert(new STable { Name = "r_s38_t3_a" });
                //_tables.Insert(new STable { Name = "r_s38_t4_a" });
                //_tables.Insert(new STable { Name = "r_s38_t5_a" });
                //_tables.Insert(new STable { Name = "r_s38_t6_a" });
                //_tables.Insert(new STable { Name = "r_s38_t7_a" });
                //_tables.Insert(new STable { Name = "r_s38_t8_a" });
                //_tables.Insert(new STable { Name = "r_s38_t9_a" });
                //_tables.Insert(new STable { Name = "r_s38_t10_a" });

                //_tables.Insert(new STable { Name = "r_s39_t1_a" });
                //_tables.Insert(new STable { Name = "r_s39_t2_a" });
                //_tables.Insert(new STable { Name = "r_s39_t3_a" });
                //_tables.Insert(new STable { Name = "r_s39_t4_a" });
                //_tables.Insert(new STable { Name = "r_s39_t5_a" });
                //_tables.Insert(new STable { Name = "r_s39_t6_a" });
                //_tables.Insert(new STable { Name = "r_s39_t7_a" });
                //_tables.Insert(new STable { Name = "r_s39_t8_a" });
                //_tables.Insert(new STable { Name = "r_s39_t9_a" });
                //_tables.Insert(new STable { Name = "r_s39_t10_a" });

                //_tables.Insert(new STable { Name = "r_s40_t1_a" });
                //_tables.Insert(new STable { Name = "r_s40_t2_a" });
                //_tables.Insert(new STable { Name = "r_s40_t3_a" });
                //_tables.Insert(new STable { Name = "r_s40_t4_a" });
                //_tables.Insert(new STable { Name = "r_s40_t5_a" });
                //_tables.Insert(new STable { Name = "r_s40_t6_a" });
                //_tables.Insert(new STable { Name = "r_s40_t7_a" });
                //_tables.Insert(new STable { Name = "r_s40_t8_a" });
                //_tables.Insert(new STable { Name = "r_s40_t9_a" });
                //_tables.Insert(new STable { Name = "r_s40_t10_a" });

                //_tables.Insert(new STable { Name = "r_s41_t1_a" });
                //_tables.Insert(new STable { Name = "r_s41_t2_a" });
                //_tables.Insert(new STable { Name = "r_s41_t3_a" });
                //_tables.Insert(new STable { Name = "r_s41_t4_a" });
                //_tables.Insert(new STable { Name = "r_s41_t5_a" });
                //_tables.Insert(new STable { Name = "r_s41_t6_a" });
                //_tables.Insert(new STable { Name = "r_s41_t7_a" });
                //_tables.Insert(new STable { Name = "r_s41_t8_a" });
                //_tables.Insert(new STable { Name = "r_s41_t9_a" });
                //_tables.Insert(new STable { Name = "r_s41_t10_a" });

                //_tables.Insert(new STable { Name = "r_s42_t1_a" });
                //_tables.Insert(new STable { Name = "r_s42_t2_a" });
                //_tables.Insert(new STable { Name = "r_s42_t3_a" });
                //_tables.Insert(new STable { Name = "r_s42_t4_a" });
                //_tables.Insert(new STable { Name = "r_s42_t5_a" });
                //_tables.Insert(new STable { Name = "r_s42_t6_a" });
                //_tables.Insert(new STable { Name = "r_s42_t7_a" });
                //_tables.Insert(new STable { Name = "r_s42_t8_a" });
                //_tables.Insert(new STable { Name = "r_s42_t9_a" });
                //_tables.Insert(new STable { Name = "r_s42_t10_a" });

                //_tables.Insert(new STable { Name = "r_s43_t1_a" });
                //_tables.Insert(new STable { Name = "r_s43_t2_a" });
                //_tables.Insert(new STable { Name = "r_s43_t3_a" });
                //_tables.Insert(new STable { Name = "r_s43_t4_a" });
                //_tables.Insert(new STable { Name = "r_s43_t5_a" });
                //_tables.Insert(new STable { Name = "r_s43_t6_a" });
                //_tables.Insert(new STable { Name = "r_s43_t7_a" });
                //_tables.Insert(new STable { Name = "r_s43_t8_a" });
                //_tables.Insert(new STable { Name = "r_s43_t9_a" });
                //_tables.Insert(new STable { Name = "r_s43_t10_a" });

                //_tables.Insert(new STable { Name = "r_s44_t1_a" });
                //_tables.Insert(new STable { Name = "r_s44_t2_a" });
                //_tables.Insert(new STable { Name = "r_s44_t3_a" });
                //_tables.Insert(new STable { Name = "r_s44_t4_a" });
                //_tables.Insert(new STable { Name = "r_s44_t5_a" });
                //_tables.Insert(new STable { Name = "r_s44_t6_a" });
                //_tables.Insert(new STable { Name = "r_s44_t7_a" });
                //_tables.Insert(new STable { Name = "r_s44_t8_a" });
                //_tables.Insert(new STable { Name = "r_s44_t9_a" });
                //_tables.Insert(new STable { Name = "r_s44_t10_a" });

                //_tables.Insert(new STable { Name = "r_s45_t1_a" });
                //_tables.Insert(new STable { Name = "r_s45_t2_a" });
                //_tables.Insert(new STable { Name = "r_s45_t3_a" });
                //_tables.Insert(new STable { Name = "r_s45_t4_a" });
                //_tables.Insert(new STable { Name = "r_s45_t5_a" });
                //_tables.Insert(new STable { Name = "r_s45_t6_a" });
                //_tables.Insert(new STable { Name = "r_s45_t7_a" });
                //_tables.Insert(new STable { Name = "r_s45_t8_a" });
                //_tables.Insert(new STable { Name = "r_s45_t9_a" });
                //_tables.Insert(new STable { Name = "r_s45_t10_a" });

                //_tables.Insert(new STable { Name = "r_s46_t1_a" });
                //_tables.Insert(new STable { Name = "r_s46_t2_a" });
                //_tables.Insert(new STable { Name = "r_s46_t3_a" });
                //_tables.Insert(new STable { Name = "r_s46_t4_a" });
                //_tables.Insert(new STable { Name = "r_s46_t5_a" });
                //_tables.Insert(new STable { Name = "r_s46_t6_a" });
                //_tables.Insert(new STable { Name = "r_s46_t7_a" });
                //_tables.Insert(new STable { Name = "r_s46_t8_a" });
                //_tables.Insert(new STable { Name = "r_s46_t9_a" });
                //_tables.Insert(new STable { Name = "r_s46_t10_a" });

                //_tables.Insert(new STable { Name = "r_s47_t1_a" });
                //_tables.Insert(new STable { Name = "r_s47_t2_a" });
                //_tables.Insert(new STable { Name = "r_s47_t3_a" });
                //_tables.Insert(new STable { Name = "r_s47_t4_a" });
                //_tables.Insert(new STable { Name = "r_s47_t5_a" });
                //_tables.Insert(new STable { Name = "r_s47_t6_a" });
                //_tables.Insert(new STable { Name = "r_s47_t7_a" });
                //_tables.Insert(new STable { Name = "r_s47_t8_a" });
                //_tables.Insert(new STable { Name = "r_s47_t9_a" });
                //_tables.Insert(new STable { Name = "r_s47_t10_a" });

                //_tables.Insert(new STable { Name = "r_s48_t1_a" });
                //_tables.Insert(new STable { Name = "r_s48_t2_a" });
                //_tables.Insert(new STable { Name = "r_s48_t3_a" });
                //_tables.Insert(new STable { Name = "r_s48_t4_a" });
                //_tables.Insert(new STable { Name = "r_s48_t5_a" });
                //_tables.Insert(new STable { Name = "r_s48_t6_a" });
                //_tables.Insert(new STable { Name = "r_s48_t7_a" });
                //_tables.Insert(new STable { Name = "r_s48_t8_a" });
                //_tables.Insert(new STable { Name = "r_s48_t9_a" });
                //_tables.Insert(new STable { Name = "r_s48_t10_a" });

                //_tables.Insert(new STable { Name = "r_s49_t1_a" });
                //_tables.Insert(new STable { Name = "r_s49_t2_a" });
                //_tables.Insert(new STable { Name = "r_s49_t3_a" });
                //_tables.Insert(new STable { Name = "r_s49_t4_a" });
                //_tables.Insert(new STable { Name = "r_s49_t5_a" });
                //_tables.Insert(new STable { Name = "r_s49_t6_a" });
                //_tables.Insert(new STable { Name = "r_s49_t7_a" });
                //_tables.Insert(new STable { Name = "r_s49_t8_a" });
                //_tables.Insert(new STable { Name = "r_s49_t9_a" });
                //_tables.Insert(new STable { Name = "r_s49_t10_a" });

                //_tables.Insert(new STable { Name = "r_s50_t1_a" });
                //_tables.Insert(new STable { Name = "r_s50_t2_a" });
                //_tables.Insert(new STable { Name = "r_s50_t3_a" });
                //_tables.Insert(new STable { Name = "r_s50_t4_a" });
                //_tables.Insert(new STable { Name = "r_s50_t5_a" });
                //_tables.Insert(new STable { Name = "r_s50_t6_a" });
                //_tables.Insert(new STable { Name = "r_s50_t7_a" });
                //_tables.Insert(new STable { Name = "r_s50_t8_a" });
                //_tables.Insert(new STable { Name = "r_s50_t9_a" });

                //_tables.Insert(new STable { Name = "r_s51_t1_a" });
                //_tables.Insert(new STable { Name = "r_s51_t2_a" });
                //_tables.Insert(new STable { Name = "r_s51_t3_a" });
                //_tables.Insert(new STable { Name = "r_s51_t4_a" });
                //_tables.Insert(new STable { Name = "r_s51_t5_a" });
                //_tables.Insert(new STable { Name = "r_s51_t6_a" });
                //_tables.Insert(new STable { Name = "r_s51_t7_a" });
                //_tables.Insert(new STable { Name = "r_s51_t8_a" });
                //_tables.Insert(new STable { Name = "r_s51_t9_a" });
                //_tables.Insert(new STable { Name = "r_s51_t10_a" });

                //_tables.Insert(new STable { Name = "r_s52_t1_a" });
                //_tables.Insert(new STable { Name = "r_s52_t2_a" });
                //_tables.Insert(new STable { Name = "r_s52_t3_a" });
                //_tables.Insert(new STable { Name = "r_s52_t4_a" });
                //_tables.Insert(new STable { Name = "r_s52_t5_a" });
                //_tables.Insert(new STable { Name = "r_s52_t6_a" });
                //_tables.Insert(new STable { Name = "r_s52_t7_a" });
                //_tables.Insert(new STable { Name = "r_s52_t8_a" });
                //_tables.Insert(new STable { Name = "r_s52_t9_a" });
                //_tables.Insert(new STable { Name = "r_s52_t10_a" });

                //_tables.Insert(new STable { Name = "r_s53_t1_a" });
                //_tables.Insert(new STable { Name = "r_s53_t2_a" });
                //_tables.Insert(new STable { Name = "r_s53_t3_a" });
                //_tables.Insert(new STable { Name = "r_s53_t4_a" });
                //_tables.Insert(new STable { Name = "r_s53_t5_a" });
                //_tables.Insert(new STable { Name = "r_s53_t6_a" });
                //_tables.Insert(new STable { Name = "r_s53_t7_a" });
                //_tables.Insert(new STable { Name = "r_s53_t8_a" });
                //_tables.Insert(new STable { Name = "r_s53_t9_a" });
                //_tables.Insert(new STable { Name = "r_s53_t10_a" });

                //_tables.Insert(new STable { Name = "r_s54_t1_a" });
                //_tables.Insert(new STable { Name = "r_s54_t2_a" });
                //_tables.Insert(new STable { Name = "r_s54_t3_a" });
                //_tables.Insert(new STable { Name = "r_s54_t4_a" });
                //_tables.Insert(new STable { Name = "r_s54_t5_a" });
                //_tables.Insert(new STable { Name = "r_s54_t6_a" });
                //_tables.Insert(new STable { Name = "r_s54_t7_a" });
                //_tables.Insert(new STable { Name = "r_s54_t8_a" });
                //_tables.Insert(new STable { Name = "r_s54_t9_a" });
                //_tables.Insert(new STable { Name = "r_s54_t10_a" });

                //_tables.Insert(new STable { Name = "r_s55_t1_a" });
                //_tables.Insert(new STable { Name = "r_s55_t2_a" });
                //_tables.Insert(new STable { Name = "r_s55_t3_a" });
                //_tables.Insert(new STable { Name = "r_s55_t4_a" });
                //_tables.Insert(new STable { Name = "r_s55_t5_a" });
                //_tables.Insert(new STable { Name = "r_s55_t6_a" });
                //_tables.Insert(new STable { Name = "r_s55_t7_a" });
                //_tables.Insert(new STable { Name = "r_s55_t8_a" });
                //_tables.Insert(new STable { Name = "r_s55_t9_a" });
                //_tables.Insert(new STable { Name = "r_s55_t10_a" });

                //_tables.Insert(new STable { Name = "r_s56_t1_a" });
                //_tables.Insert(new STable { Name = "r_s56_t2_a" });
                //_tables.Insert(new STable { Name = "r_s56_t3_a" });
                //_tables.Insert(new STable { Name = "r_s56_t4_a" });
                //_tables.Insert(new STable { Name = "r_s56_t5_a" });
                //_tables.Insert(new STable { Name = "r_s56_t6_a" });
                //_tables.Insert(new STable { Name = "r_s56_t7_a" });
                //_tables.Insert(new STable { Name = "r_s56_t8_a" });
                //_tables.Insert(new STable { Name = "r_s56_t9_a" });
                //_tables.Insert(new STable { Name = "r_s56_t10_a" });

                //_tables.Insert(new STable { Name = "r_s57_t1_a" });
                //_tables.Insert(new STable { Name = "r_s57_t2_a" });
                //_tables.Insert(new STable { Name = "r_s57_t3_a" });
                //_tables.Insert(new STable { Name = "r_s57_t4_a" });
                //_tables.Insert(new STable { Name = "r_s57_t5_a" });
                //_tables.Insert(new STable { Name = "r_s57_t6_a" });
                //_tables.Insert(new STable { Name = "r_s57_t7_a" });
                //_tables.Insert(new STable { Name = "r_s57_t8_a" });
                //_tables.Insert(new STable { Name = "r_s57_t9_a" });
                //_tables.Insert(new STable { Name = "r_s57_t10_a" });

                //_tables.Insert(new STable { Name = "r_s58_t1_a" });
                //_tables.Insert(new STable { Name = "r_s58_t2_a" });
                //_tables.Insert(new STable { Name = "r_s58_t3_a" });
                //_tables.Insert(new STable { Name = "r_s58_t4_a" });
                //_tables.Insert(new STable { Name = "r_s58_t5_a" });
                //_tables.Insert(new STable { Name = "r_s58_t6_a" });
                //_tables.Insert(new STable { Name = "r_s58_t7_a" });
                //_tables.Insert(new STable { Name = "r_s58_t8_a" });
                //_tables.Insert(new STable { Name = "r_s58_t9_a" });
                //_tables.Insert(new STable { Name = "r_s58_t10_a" });

                //_tables.Insert(new STable { Name = "r_s59_t1_a" });
                //_tables.Insert(new STable { Name = "r_s59_t2_a" });
                //_tables.Insert(new STable { Name = "r_s59_t3_a" });
                //_tables.Insert(new STable { Name = "r_s59_t4_a" });
                //_tables.Insert(new STable { Name = "r_s59_t5_a" });
                //_tables.Insert(new STable { Name = "r_s59_t6_a" });
                //_tables.Insert(new STable { Name = "r_s59_t7_a" });
                //_tables.Insert(new STable { Name = "r_s59_t8_a" });
                //_tables.Insert(new STable { Name = "r_s59_t9_a" });
                //_tables.Insert(new STable { Name = "r_s59_t10_a" });

                //_tables.Insert(new STable { Name = "r_s60_t1_a" });
                //_tables.Insert(new STable { Name = "r_s60_t2_a" });
                //_tables.Insert(new STable { Name = "r_s60_t3_a" });
                //_tables.Insert(new STable { Name = "r_s60_t4_a" });
                //_tables.Insert(new STable { Name = "r_s60_t5_a" });
                //_tables.Insert(new STable { Name = "r_s60_t6_a" });
                //_tables.Insert(new STable { Name = "r_s60_t7_a" });
                //_tables.Insert(new STable { Name = "r_s60_t8_a" });
                //_tables.Insert(new STable { Name = "r_s60_t9_a" });
                //_tables.Insert(new STable { Name = "r_s60_t10_a" });



            }
        }
        //Points
        public List<SPoint> GetPoint()
        {
            return _points.Find(point => true).ToList();
        }

        public SPoint GetPoint(int id)
        {
            return _points.Find(point => point.Id == id).FirstOrDefault();
        }

        public SPoint GetPoint(string pid)
        {
            return _points.Find(point => point.PID == pid).FirstOrDefault();
        }
        public SPoint CreatePoint(string pid)
        {
            var point = new SPoint { PID = pid };
            _points.Insert(point);
            AddPointToRDB(pid);
            return point;
        }

        public SPoint CreatePoint(SPoint point)
        {
            _points.Insert(point);
            AddPointToRDB(point.PID);
            return point;
        }


        public bool RemovePoint(SPoint point)
        {
            return RemovePoint(point.PID);
        }

        public bool RemovePoint(string pid)
        {
            if (_points.Delete(x => x.PID.Equals(pid)) > 0)
            {
                RemovePointToRDB(pid);
                return true;
            }
            return false;

        }
        private void AddPointToRDB(string pid)
        {
            if (_rdbService.Started && _rdbService.Actived)
            {
                if (_rdbService.Actived)
                {
                        var point = _rdbService.GetPoint(pid);
                        if (point != null)
                        {
                            _subscribePointDictionary.AddAndSet(point);
                        }
                   
                }

            }

        }
        private void RemovePointToRDB(string pid)
        {
            if (_rdbService.Started && _rdbService.Actived)
            {
                _subscribePointDictionary.Remove(pid);
            }
        }
        private void AddTableToRDB(string name)
        {
            if (_rdbService.Actived)
            {             
                    var points = _rdbService.GetTablePoints(name);
                    foreach (var point in points)
                    {
                        if (point != null)
                        {
                            _subscribePointDictionary.AddAndSet(point);
                        }

                    }
            

            }
        }
        private void RemoveTableToRDB(string name)
        {
            if ( _rdbService.Actived)
            {
                _subscribePointDictionary.RemoveTable(name);

            }
        }

        //Tables
        public List<STable> GetTable()
        {
            return _tables.Find(table => true).ToList();
        }

        public STable GetTable(string name)
        {
            return _tables.Find(table => table.Name == name).FirstOrDefault();
        }

        public STable CreateTable(STable table)
        {
            _tables.Insert(table);
            AddTableToRDB(table.Name);
            return table;
        }


        public bool RemoveTable(STable table)
        {
            return RemoveTable(table.Name);
        }

        public bool RemoveTable(string name)
        {
            if (_tables.Delete(x => x.Name.Equals(name)) > 0)
            {
                RemoveTableToRDB(name);

                return true;

            }
            return false;


        }
    }
}


