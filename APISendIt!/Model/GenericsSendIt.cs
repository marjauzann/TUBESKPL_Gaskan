namespace APISendIt_.Model
{
    public class genericsMentorship<T>
    {
        public int Id { get; set; }
        public T KurirID { get; set; }
        public T PenggunaID { get; set; }

        public genericsMentorship(int Id, T kurirID, T penggunaID)
        {
            this.Id = Id;
            KurirID = kurirID;
            PenggunaID = penggunaID;
        }
    }
}
