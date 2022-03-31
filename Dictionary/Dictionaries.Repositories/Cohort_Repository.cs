public class Cohort_Repository
{
    private readonly List<Cohort> _cohortDb = new List<Cohort>();
    private int _count = 0;
    public bool AddCohortToDb(Cohort cohort)
    {
        return AddToDatabase(AssignCohortID(cohort));
    }
    private bool AddToDatabase(Cohort cohort)
    {
        _cohortDb.Add(cohort);
        return true;
    }
    private Cohort AssignCohortID(Cohort cohort)
    {
        _count++;
        cohort.ID = _count;
        return cohort;
    }
    public List<Cohort> GetCohorts()
    {
        return _cohortDb;
    }
    public Cohort GetCohortByID(int id)
    {
        foreach (var cohort in _cohortDb)
        {
            if (cohort.ID == id)
            {
                return cohort;
            }
        }
        return null;
    }
    public bool UpdateCohort(int id, Cohort newCohortData)
    {
        var oldCohort = GetCohortByID(id);
        if (oldCohort != null)
        {
            oldCohort.ClassNumber = newCohortData.ClassNumber;
            return true;
        }
        return false;
    }
    public bool DeleteCohort(int id)
    {
        var cohortToDelete = GetCohortByID(id);
        return _cohortDb.Remove(cohortToDelete);
    }
}
