export const getNews = state => {
    const { news } = state;
    return news ? news.notifications : null;
};

export const getNewsLoading = state => {
    const { news } = state;
    return news.loading;
};
