export const getNews = state => {
    const { news } = state;
    return news && news.data ? news.data.notifications : null;
};

export const getNewsLoading = state => {
    const { news } = state;
    return news.loading;
};
