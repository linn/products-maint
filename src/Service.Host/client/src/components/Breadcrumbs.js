import React, { Component } from 'react';
import { Breadcrumb, BreadcrumbItem } from 'reactstrap';

class Breadcrumbs extends Component {
    render() {
        const { location, history, rootPathLength = 2 } = this.props;

        const crumbs = location.pathname
            .split('/')
            .reduce((sofar, crumb, i, crumbs) => {
                const path = crumbs.slice(0, i + 1);
                const href = path.join('/') || '/';

                const handleClick = e => {
                    // we should just let the browser handle any paths 
                    // shorter than our root path, e.g.the 'Home' path
                    if (path.length > rootPathLength) {
                        e.preventDefault();
                        history.push(href);
                    }
                };

                return [
                    ...sofar,
                    <BreadcrumbItem key={i} caption={crumb || 'Home'} onClick={e => handleClick(e)} ><a href={href}> {crumb || 'Home'}</a> </BreadcrumbItem>
                ];
            }, []);

        return (
            <Breadcrumb>
                {crumbs}
            </Breadcrumb>
        );
    }
}

export default Breadcrumbs;
