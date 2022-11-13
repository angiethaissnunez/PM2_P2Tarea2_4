using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PM2_P2Tarea2_4.Controller
{
    public class BaseDatosVideo
    {
        readonly SQLiteAsyncConnection basedatos;

        public BaseDatosVideo(string path)
        {
            basedatos = new SQLiteAsyncConnection(path);

            basedatos.CreateTableAsync<Models.Videos>();
        }

        #region OperacionesVideo
        //Metodos CRUD - CREATE
        public Task<int> insertUpdateVideo(Models.Videos video)
        {
            if (video.id != 0)
            {
                return basedatos.UpdateAsync(video);
            }
            else
            {
                return basedatos.InsertAsync(video);
            }
        }

        //Metodos CRUD - READ
        public Task<List<Models.Videos>> getListVideo()
        {
            return basedatos.Table<Models.Videos>().ToListAsync();
        }

        public Task<Models.Videos> getVideo(int id)
        {
            return basedatos.Table<Models.Videos>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }



        #endregion OperacionesVideo
    }
}
