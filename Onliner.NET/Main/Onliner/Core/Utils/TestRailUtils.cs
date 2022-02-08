using Gurock.TestRail;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Onliner.NET.Main.Onliner.Core.Utils
{
    public class TestRailUtils
    {
        private const string Id = "id";

        private static APIClient client = new APIClient("https://arsenylearningapi.testrail.io/")
        {
            User = "teoerse@gmail.com",
            Password = "vlVfArbn1.UwRLaN8UMj"
        };

        public static int AddResultForCase(int testId, int testStatusId, string comment)
        {
            var _object = new Dictionary<string, string>
            {
                { "status_id", $"{testStatusId}" },
                { "comment", comment }
            };
            var _resultObject = client.SendPost($"add_result/{testId}", _object);
            var _resultJO = JObject.Parse(JsonConvert.SerializeObject(_resultObject));
            return (int)_resultJO[Id];
        }

        public static int CreateTestProject()
        {
            var _object = new Dictionary<string, string>
            {
                { "name", "Test Project: " + DateTime.Now.ToString()}
            };
            var _projectObject = client.SendPost($"add_project", _object);
            var _projectJO = JObject.Parse(JsonConvert.SerializeObject(_projectObject));
            return (int)_projectJO[Id];
        }

        public static int GetTest(int runId)
        {
            var _testObject = client.SendGet($"get_tests/{runId}");
            var _testJO = JObject.Parse(JsonConvert.SerializeObject(_testObject));
            var asfasfaf = _testJO["tests"];
            return (int)_testJO["tests"].Last[Id];
        }

        public static int CreateTestSuite(int projectId)
        {
            var _object = new Dictionary<string, string>
            {
                { "name",  DateTime.Now.ToString()}
            };
            var _suiteObject = client.SendPost($"add_suite/{projectId}", _object);
            var _suiteJO = JObject.Parse(JsonConvert.SerializeObject(_suiteObject));
            return (int)_suiteJO[Id];
        }

        public static int CreateTestSection(int projectId, int suiteId)
        {
            var _object = new Dictionary<string, string>
            {
                { "name",  DateTime.Now.ToString()},
                { "suite_id",  Convert.ToString(suiteId)}
            };
            var _sectionObject = client.SendPost($"add_section/{projectId}", _object);
            var _sectionJO = JObject.Parse(JsonConvert.SerializeObject(_sectionObject));
            return (int)_sectionJO[Id];
        }

        public static int CreateTestRun(int projectId, int suiteId)
        {
            var _object = new Dictionary<string, string>
            {
                { "name",  DateTime.Now.ToString()},
                { "suite_id",  Convert.ToString(suiteId)}
            };
            var _runObject = client.SendPost($"add_run/{projectId}", _object);
            var _runJO = JObject.Parse(JsonConvert.SerializeObject(_runObject));
            return (int)_runJO[Id];
        }

        public static int CreateTestCase(int sectionId, string title)
        {
            var _object = new Dictionary<string, string>
            {
                { "title",  title}
            };
            var _caseObject = client.SendPost($"add_case/{sectionId}", _object);
            var _caseJO = JObject.Parse(JsonConvert.SerializeObject(_caseObject));
            return (int)_caseJO[Id];
        }
        /***
         * Method for deleting all projects from testrail!
         */
        public static void DeleteProjects()
        {
            var projects = client.SendGet($"get_projects");
            var _projectsJO = JObject.Parse(JsonConvert.SerializeObject(projects));
            var JOprojects = _projectsJO["projects"];
            foreach (var project in JOprojects)
            {
                var _object = new Dictionary<string, string>
                {
                    { "project_id",  Convert.ToString(project[Id])}
                };
                client.SendPost($"delete_project/{project[Id]}", _object);
            }  
        }
    }
}
