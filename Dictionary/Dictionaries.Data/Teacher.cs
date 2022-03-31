
public class Teacher
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Cohort> Cohorts { get; set; } = new List<Cohort>();
}
