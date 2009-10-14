namespace nothinbutdotnetstore.dto
{
    public class Department
    {
        string local_department_name;
        public Department(string department_name)
        {
            this.local_department_name = department_name;
        }

        public string department_name
        {
            get {
                return local_department_name; }
        }
    
    }
}