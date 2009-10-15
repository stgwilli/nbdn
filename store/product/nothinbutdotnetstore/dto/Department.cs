namespace nothinbutdotnetstore.dto
{
    public class Department
    {
        public Department() {}

        public Department(string department_name)
        {
            this.department_name = department_name;
        }

        public string department_name { get; set; }
    }
}