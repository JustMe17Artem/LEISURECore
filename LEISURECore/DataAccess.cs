using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace LEISURECore
{
    public class DataAccess
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["LEISUREEntities"].ConnectionString;
        private static IDbConnection connection = new SqlConnection(connStr);

        //public static void DeleteVisiting(int id)
        //{

        //    connection.Query($"delete from [dbo].Visiting where [ID_OV]={id}" );
        //}

        //Нестёртый неиспользуемый фрагмент кода (не критично)
        public static List<Event> Refreshing()
        {
            List<Event> eventss = new List<Event>(DBConnection.connection.Event);
            List<Event> events = new List<Event>();
            DateTime current_day = DateTime.Now;
            foreach (var i in eventss)
            {
                if (current_day >= i.Date_Start && current_day <= i.Date_End)
                {
                    i.Status = "Проходит";
                }
                else if (current_day > i.Date_End)
                {
                    i.Status = "Закончилось";
                }
                else if (current_day < i.Date_Start)
                {
                    i.Status = "Скоро начнётся";
                }
                
                
            }
            DBConnection.connection.SaveChanges();
            return events;
        }

        //Осмысленные названия методов. У методов по несколько перегрузок, код понятен (очень хорошо)

        public static List<Object> GetObjects()
        {
            List<Object> objectss = new List<Object>(DBConnection.connection.Object);
            List<Object> objects = new List<Object>();
            foreach (var o in objectss)
            {
                objects.Add(new Object
                {
                    ID_Object = o.ID_Object,
                    Name = o.Name,
                    Adress = o.Adress,
                    Capacity = o.Capacity,
                    Status = o.Status
                });

            }
            
            return objects;
        }
        public static bool AddNewVisiting(Visiting visiting)
        {
            try
            {
                DBConnection.connection.Visiting.Add(visiting);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddNewVisiting(Nullable<int> IdObject, Nullable<DateTime> date, Nullable<int> IdEvent)
        {
            try
            {
                Visiting visiting = new Visiting()
                {
                    ID_Event = IdEvent,
                    ID_Object = IdObject,
                    Date = date
                };
                
                DBConnection.connection.Visiting.Add(visiting);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void AttendancePlus(int IdObject, int att)
        {
            Object selected_object = new Object()
            {
                ID_Object = IdObject,
                Attendance = att

            };
            selected_object.Attendance += 1;
           
            DBConnection.connection.SaveChanges();
        }
        public static bool AddNewVisiting(Nullable<int> idObject, Nullable<DateTime> date)
        {
            try
            {

                Visiting visiting = new Visiting()
                {
                    ID_Object = idObject,
                    Date = date
                };
                
                DBConnection.connection.Visiting.Add(visiting);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddNewObject(Object new_object)
        {
            try
            {
                DBConnection.connection.Object.Add(new_object);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddNewObject(string name, int id_type, string adress, int capacity)
        {
            try
            {
                Object new_object = new Object()
                {
                    Name = name,
                    ID_Type = id_type,
                    Adress = adress,
                    Capacity = capacity,
                    Status = "Открыт",
                    Attendance = 0,
                    Opened = true

                };
                DBConnection.connection.Object.Add(new_object);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddNewRequest(Request request)
        {
            try
            {
                DBConnection.connection.Request.Add(request);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddNewRequest(int IdObj, string name, int IdType, DateTime start, DateTime end, string phone)
        {
            try
            {
                Request request = new Request()
                {
                    Name = name,
                    ID_Object = IdObj,
                    ID_Type_Event = IdType,
                    Date_End = end,
                    Date_Start = start,
                    Contact_Phone = phone

                };
                DBConnection.connection.Request.Add(request);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static List<Type_Object> GetTypeObjects()
        {
            List<Type_Object> types = new List<Type_Object>(DBConnection.connection.Type_Object);
            List<Type_Object> typess = new List<Type_Object>();
            foreach (var part in types)
            {
                typess.Add(
                    new Type_Object
                    {
                        ID_Type = part.ID_Type,
                        Name_Type = part.Name_Type
                    });
            }
            return typess;
        }
        public static List<Users> GetUsers()
        {
            List<Users> users = new List<Users>(DBConnection.connection.Users);
            List<Users> userss = new List<Users>();
            foreach(var u in users)
            {
                userss.Add(
                    new Users
                    {
                        ID_User = u.ID_User,
                        Name = u.Name
                    });
            }
            return userss;
        }
        public static Users GetUser(int idUser)
        {
            List<Users> users = GetUsers();
            var u = users.Where(a => a.ID_User == idUser).FirstOrDefault();
            return u;
        }
        public static void DeleteUser(int idUser)
        {
            Users user = DBConnection.connection.Users.FirstOrDefault(a => a.ID_User == idUser);
            DBConnection.connection.Users.Remove(user);
            DBConnection.connection.SaveChanges();

        }

        public static void UpdateUser(Users user)
        {
            var u = DBConnection.connection.Users.SingleOrDefault(r => r.ID_User== user.ID_User);
            u.ID_User = user.ID_User;
            u.Name = user.Name;
            DBConnection.connection.SaveChanges();

        }
        public static List<Type_Event> GetTypeEvents()
        {
            List<Type_Event> types = new List<Type_Event>(DBConnection.connection.Type_Event);
            List<Type_Event> typess = new List<Type_Event>();
            foreach (var e in types)
            {
                typess.Add(
                    new Type_Event
                    {
                        ID_Type = e.ID_Type,
                        Name_type = e.Name_type
                    });
            }
            return typess;
            
        }
        public static Type_Event GetTypeEvent(int idType_Event)
        {
            List<Type_Event> types = GetTypeEvents();
            var tEv = types.Where(to => to.ID_Type == idType_Event).FirstOrDefault();
            return tEv;
        }
        public static Type_Object GetTypeObject(int idType_Object)
        {
            List<Type_Object> types = GetTypeObjects();
            var tObj = types.Where(to => to.ID_Type == idType_Object).FirstOrDefault();
            return tObj;
        }
        public static List<Event> GetEvents()
        {
            List<Event> events = new List<Event>(DBConnection.connection.Event.Where(a=> a.Status != "Закончилось"));
            List<Event> eventss = new List<Event>();
            foreach(var e in events)
            {
                eventss.Add(
                    new Event
                    {
                        Name = e.Name,
                        Date_Start = e.Date_Start,
                        Date_End = e.Date_End,
                        Attendance = e.Attendance,
                        Status = e.Status,
                    });
               
            }
            return eventss;
        }
        public static Event GetEvent(int idEvent)
        {
            List<Event> events = GetEvents();
            return events.Where(o => o.ID_Event== idEvent).FirstOrDefault();
        }
        public static Event GetEvent(string name)
        {
            List<Event> events = GetEvents();
            return events.Where(o => o.Name == name).FirstOrDefault();
        }
        public static List<Request> GetRequests()
        {
            List<Request> requests = new List<Request>(DBConnection.connection.Request);
            List<Request> requestss = new List<Request>();
            foreach (var r in requests)
            {
                requestss.Add(
                    new Request
                    {
                        Name = r.Name,
                        Date_Start = r.Date_Start,
                        Date_End = r.Date_End,
                        Contact_Phone = r.Contact_Phone
                        
                    });

            }
            return requestss;
        }
        public static Request GetRequest(int idRequest)
        {
            List<Request> requests = GetRequests();
            return requests.Where(r => r.ID_Request== idRequest).SingleOrDefault();
        }
        public static void DeleteRequest(int idRequest)
        {
            Request request = DBConnection.connection.Request.FirstOrDefault(p => p.ID_Request == idRequest);
            DBConnection.connection.Request.Remove(request);
            DBConnection.connection.SaveChanges();

        }

        public static Object GetObject(int idObject)
        {
            List<Object> objects = GetObjects();
            return objects.Where(o => o.ID_Object == idObject).FirstOrDefault();
        }

        public static Object GetObject(string name)
        {
            List<Object> objects = GetObjects();
            return objects.Where(o => o.Name == name).FirstOrDefault();
        }
        public static bool AddNewEvent(Event new_event)
        {
            try
            {
                DBConnection.connection.Event.Add(new_event);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddNewEvent(Nullable<int> IdObj, string name, Nullable<int> IdType, Nullable<DateTime> start, Nullable<DateTime> end )
        {
            try
            {
                Event new_event = new Event()
                {
                    Name = name,
                    ID_Object = IdObj,
                    ID_Type = IdType,
                    Date_End = end,
                    Date_Start = start,
                    Available = true,
                    Status = "Скоро начнётся",
                    Attendance = 0

                };
                DBConnection.connection.Event.Add(new_event);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool AddNewTypeEvent(Type_Event type)
        {
            try
            {
                DBConnection.connection.Type_Event.Add(type);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddNewTypeEvent(string name)
        {
            try
            {
                Type_Event type = new Type_Event()
                {
                    Name_type = name
                    

                };
                DBConnection.connection.Type_Event.Add(type);
                DBConnection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void DeleteTypeEvent(int idType_Event)
        {
            List<Type_Event> events = GetTypeEvents();
            var type = events.Where(t => t.ID_Type== idType_Event).FirstOrDefault();
            DBConnection.connection.Type_Event.Remove(type);
            DBConnection.connection.SaveChanges();
        }
        public static void DeleteVisiting(int idVisiting)
        {

            Visiting visiting = DBConnection.connection.Visiting.FirstOrDefault(p => p.ID_OV == idVisiting);
            DBConnection.connection.Visiting.Remove(visiting);
            DBConnection.connection.SaveChanges();

        }

        public static void DeleteTypeEvent(Type_Event type)
        {
            DBConnection.connection.Type_Event.Remove(type);
            DBConnection.connection.SaveChanges();
        }
        public static void UpdateEventType(int idEvent_type, Type_Event type)
        {

            DBConnection.connection.Type_Event.SingleOrDefault(t => t.ID_Type == idEvent_type);
            DBConnection.connection.SaveChanges();

        }
        public static void UpdateObject(int idObject)
        {
            var o = DBConnection.connection.Object.SingleOrDefault(t => t.ID_Object == idObject);
            o.Attendance += 1;
            DBConnection.connection.SaveChanges();

        }
        
        public static void UpdateObjecttype(int idObject_type, Type_Object type)
        {

            DBConnection.connection.Type_Object.SingleOrDefault(t => t.ID_Type == idObject_type);
            DBConnection.connection.SaveChanges();

        }
        public static List<Visiting> GetVisitings()
        {
            List<Visiting> visitingss = new List<Visiting>(DBConnection.connection.Visiting);
            List<Visiting> visitings = new List<Visiting>();
            foreach (var o in visitingss)
            {
                visitings.Add(new Visiting
                {
                    ID_OV = o.ID_OV,
                    ID_Object = o.ID_Object,
                    ID_Event = o.ID_Event,
                    ID_Visitor = o.ID_Visitor,
                    
                });

            }

            return visitings;
        }
        public static Visiting GetVisiting(int idOV)
        {
            List<Visiting> visitings = GetVisitings();
            return visitings.Where(o => o.ID_OV == idOV).FirstOrDefault();
        }
        public static void UpdateVisiting(int idVisitting, Visiting visiting)
        {

            DBConnection.connection.Visiting.SingleOrDefault(t => t.ID_OV == idVisitting);
            DBConnection.connection.SaveChanges();

        }
    }

}
