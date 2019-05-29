export const getNews = state => {
    const { news } = state;
    return news.data;
};

export const getNewsLoading = state => {
    const { news } = state;
    return news.loading;
};
