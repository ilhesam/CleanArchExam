using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Security;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappers.Resolvers
{
    public class PasswordResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, string> where TSource : IPassword where TDestination : IPassword
    {
        public string Resolve(TSource source, TDestination destination, string destMember, ResolutionContext context)
            => source.Password.EncodePasswordMd5();
    }
}
