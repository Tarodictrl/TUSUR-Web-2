using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly GroupModel _coreModel;

        public HomeController(GroupModel coreModel)
        {
            _coreModel = coreModel;
        }

        public IActionResult Index()
        {
            var coreModel = new GroupModel
            {
                Groups = _coreModel.Groups
            };
            return View("index", coreModel);
        }

        [HttpPost]
        public IActionResult AddStudent(GroupModel coreModel)
        {
            var newStudent = coreModel.NewStudent;
            if (ModelState.IsValid)
            {
                if (IsSpecialStudent(newStudent))
                {
                    coreModel.ShowGroups = true;
                }
                else
                {
                    coreModel.ShowGroups = false;
                    var group = GetOrCreateGroup(newStudent.GroupName);

                    if (!IsDuplicateStudent(group, newStudent))
                    {
                        group.Students.Add(newStudent);
                        coreModel.Message =
                            $"Студент {newStudent.Surname} {newStudent.Name} {newStudent.Patronymic} успешно добавлен в группу {newStudent.GroupName}.";
                        coreModel.NewStudent = new Student();
                    }
                    else
                    {
                        coreModel.Message = $"Невозможно добавить студента - {newStudent.Surname} {newStudent.Name} {newStudent.Patronymic} " +
                            $"уже есть в группе {newStudent.GroupName}.";
                    }

                    coreModel.CurrentGroup = group;
                }
            }
            else
            {
                coreModel.Message = $"Ошибка при добавлении студента в группу. Перепроверьте введеные данные.";
            }
            coreModel.Groups = _coreModel.Groups;
            return View("index", coreModel);
        }

        private bool IsSpecialStudent(Student student)
        {
            return student.Surname == "Мурзин" && student.Name == "Евгений" && student.Patronymic == "Сергеевич";
        }

        private Group GetOrCreateGroup(string groupName)
        {
            var group = _coreModel.Groups.FirstOrDefault(g => g.Name == groupName);

            if (group == null)
            {
                group = new Group(groupName);
                _coreModel.Groups.Add(group);
            }

            return group;
        }

        private bool IsDuplicateStudent(Group group, Student student)
        {
            return group.Students.Any(s =>
                s.Surname == student.Surname &&
                s.Name == student.Name &&
                s.Patronymic == student.Patronymic);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
