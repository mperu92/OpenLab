import React from 'react';
import PropTypes from 'prop-types';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import { toast } from 'react-toastify';

import * as newsActions from '../../../redux/actions/newsActions';
// import * as commonActions from '../../../redux/actions/commonActions';
import Spinna from '../../common/Spinna';
import NewsList from './NewsList';

class NewsPage extends React.Component {
    DisplayName = 'OpenLab--NewsPage--Front';

    componentDidMount() {
        const { newsList, actions } = this.props;
        if (newsList.length === 0) {
            try {
                actions.loadNewsList(false);
            } catch (error) {
                if (error) {
                    toast.error(error);
                } else {
                    toast.error('error loading news');
                }
            }
        }
    }

    render() {
        const { loading, newsList } = this.props;
        return (
            <div className="container news-page-container">
                <h1>News</h1>
                {loading ? (
                    <Spinna />
                ) : (
                    <>
                        <NewsList
                          newsList={newsList}
                        />
                    </>
                )}
            </div>
        );
    }
}

NewsPage.propTypes = {
    newsList: PropTypes.arrayOf(PropTypes.object).isRequired,
    // eslint-disable-next-line react/forbid-prop-types
    // common: PropTypes.object.isRequired,
    // eslint-disable-next-line react/forbid-prop-types
    // history: PropTypes.object.isRequired,
    actions: PropTypes.shape({
        loadNewsList: PropTypes.func,
        // deleteNews: PropTypes.func,
        // clearCommon: PropTypes.func,
    }).isRequired,
    loading: PropTypes.bool.isRequired,
};

function mapStateToProps(state) {
    return {
        newsList: state.newsList.length > 0 ? state.newsList : [],
        // common: state.common && state.common.file ? state.common : {},
        loading: state.apiCallsInProgress > 0,
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: {
            loadNewsList: bindActionCreators(newsActions.loadNewsList, dispatch),
            // deleteNews: bindActionCreators(newsActions.deleteNews, dispatch),
            // clearCommon: bindActionCreators(commonActions.clearCommon, dispatch),
        },
    };
}

export default withRouter(connect(
    mapStateToProps,
    mapDispatchToProps,
)(NewsPage));
