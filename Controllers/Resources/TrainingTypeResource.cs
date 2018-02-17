namespace Szkolimy_za_darmo_api.Controllers.Resources
{
    public class TrainingTypeResource
    {
        public int TrainingId{get; set;}
        public string TypeName{get; set;}
        public TrainingResource Training {get; set;}
        public TypeResource Type {get; set;}
    }
}