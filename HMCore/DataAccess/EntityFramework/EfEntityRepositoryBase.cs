using HMCore.DataAccess;
using HMCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace HMCore.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // using kullanmamızın amacı kullanmış oldugumuz nesne ile isimiz bittiginde garbage collector'a bu nesneyi bellekten temizleme komutunu gondermis oluyoruz.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);        // context.Entry(entity) bu komut ile veritabanımız ile eklenecek nesne arasinda referansını ilişkilendirme islemini tanımladık.
                addedEntity.State = EntityState.Added;          // referansları eşleşen veritabanı ile nesne arasinda yapilacak islemi tanimliyoruz.
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
                    
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                // Product tablomuz icerisinden tek bir urun getirme islemi yapacagimiz durumlarda SingleOrDefault metodunu kullanırız. Birden fazla urun gelse dahi 0 degeri dondurerek programın hata vermesinin onune gecer.
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                // filter parametresi bos ise Product tablosunu listeliyoruz bos degil ise Product tablomuza Where kosulu tanimliyoruz.Ve ona parametre olarak filter'i gonderme islemi yaparak istedigimiz urunu getirtiyoruz.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {

            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }

}
