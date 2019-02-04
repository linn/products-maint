﻿export const getHref = (itemWithLinks, rel) => {
    if (itemWithLinks && itemWithLinks.links && itemWithLinks.links.length > 0) {
        const link = itemWithLinks.links.find(l => l.rel === rel);

        return link ? link.href : null;
    }

    return null;
};

export const getSelfHref = itemWithLinks => getHref(itemWithLinks, 'self');

export const makeNumber = (str, defaultValue = 0) => {
    const result = Number(str);
    return Number.isNaN(result) ? defaultValue : result;
};
