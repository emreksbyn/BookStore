using BookStore.Application.Models.DTOs;
using BookStore.Persistence.Extensions;
using BookStore.Persistence.Grid.Utilities;
using Microsoft.AspNetCore.Http;

namespace BookStore.Persistence.Grid.Base
{
    public class GridBuilder
    {
        private const string RouteKey = "currentroute";
        public RouteDictionary Routes { get; set; }
        public ISession Session { get; set; }

        public GridBuilder(ISession session)
        {
            Session = session;
            Routes = Session.GetObject<RouteDictionary>(RouteKey) ?? new RouteDictionary();
        }

        public GridBuilder(ISession session, GridDTO values, string defaultSortField)
        {
            Session = session;
            Routes = new RouteDictionary();
            Routes.PageNumber = values.PageNumber;
            Routes.PageSize = values.PageSize;
            Routes.SortField = values.SortField ?? defaultSortField;
            Routes.SortDirection = values.SortDirection;
            SaveRouteSegment();
        }

        public void SaveRouteSegment()
        {
            Session.SetObject<RouteDictionary>(RouteKey, Routes);
        }

        public int GetTotalPages(int count)
        {
            int size = Routes.PageSize;
            return (count + size - 1) / size;
        }

        public RouteDictionary CurrentRoute => Routes;
    }
}