import React, { Fragment } from 'react';
<<<<<<< HEAD
import PropTypes from 'prop-types';
import { Page, Loading, EntityList, CreateButton } from '@linn-it/linn-form-components-library';
=======
import { Link } from 'react-router-dom';
import { withStyles } from '@material-ui/core/styles';
import { List, ListItem, Paper, Typography } from '@material-ui/core';
import { ErrorCard } from '@linn-it/linn-form-components-library';
import CircularLoading from './common/CircularLoading';
>>>>>>> master

const SernosConfigs = ({ sernosConfigs, loading, history }) => (
    <Page history={history}>
        {loading ? (
            <Loading />
        ) : (
            <Fragment>
                <CreateButton createUrl="/products/maint/sernos-configs/create" />
                <EntityList
                    title="Sernos Configs"
                    entityList={sernosConfigs}
                    entityId="name"
                    loading={loading}
                    descriptionFieldName="description"
                />
            </Fragment>
        )}
    </Page>
);

SernosConfigs.propTypes = {
    sernosConfigs: PropTypes.arrayOf(PropTypes.shape({})).isRequired,
    history: PropTypes.shape.isRequired,
    loading: PropTypes.bool.isRequired
};

export default SernosConfigs;
