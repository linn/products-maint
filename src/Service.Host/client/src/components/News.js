import React, { Fragment } from 'react';

function News({ news }) {
    if (news) {
        return news.notifications.map(item => <div>{item.title}</div>);
    }
    return <Fragment />;
}

export default News;
