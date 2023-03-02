namespace Controllers
{
    public class IdConvert{
        
        public static int Convert (string id){
            try {
                return int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
        }
    }
}