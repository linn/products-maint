// import { connect } from 'react-redux';
// import { TypeaheadDialog } from '@linn-it/linn-form-components-library';
// import tariffsActions from '../../actions/tariffs';
// import tariffsSelectors from '../../selectors/tariffsSelectors';

// const mapStateToProps = (state, { onSelect, title }) => ({
//     title,
//     onSelect,
//     searchItems: tariffsSelectors
//         .getSearchItems(state)
//         .map(w => ({ ...w, id: w.tariffCode, name: w.description })),
//     loading: tariffsSelectors.getSearchLoading(state)
// });

// const mapDispatchToProps = {
//     fetchItems: tariffsActions.search,
//     clearSearch: tariffsActions.clearSearch
// };

// export default connect(mapStateToProps, mapDispatchToProps)(TypeaheadDialog);
