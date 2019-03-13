import React, { useEffect } from 'react';

const initialiseOnMount = ComposedComponent =>
    function HOC(props) {
        const { initialise, itemId } = props;
        useEffect(() => {
            if (initialise) {
                initialise({ itemId });
            }
        }, [initialise, itemId]);

        return <ComposedComponent {...props} />;
    };

export default initialiseOnMount;
