import React from 'react';
import PropTypes from 'prop-types';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Redirect } from 'react-router-dom';
import { toast } from 'react-toastify';

import * as newsActions from '../../../redux/actions/newsActions';
import * as commonActions from '../../../redux/actions/commonActions';
import Spinna from '../../common/Spinna';
import NewsList from './NewsList';

class NewsPage extends React.Component {
    DisplayName = 'OpenLab--NewsPage';

    constructor(props) {
        super(props);

        this.state = {
            redirectToAddNewsPage: false,
        };
    }

    componentDidMount() {
        const { newsList, common, actions } = this.props;
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
            // actions.loadNewsList(false)
            // .catch((error) => {
            //     toast.error(error);
            // });
        }
        debugger;
        if (common && common.file) {
            try {
                actions.clearCommon();
            } catch (error) {
                if (error) {
                    toast.error(error);
                } else {
                    toast.error('error clearing common state');
                }
            }
        }
    }

    handleDeleteNews = async (news) => {
        const { actions } = this.props;
        toast.success('News deleted');
        // async await instead of promise
        try {
            await actions.deleteNews(news);
        } catch (error) {
            toast.error(`News deleting failed. ${error.message}`, { autoClose: false });
        }
    }

    render() {
        const { redirectToAddNewsPage } = this.state;
        const { loading, newsList } = this.props;
        return (
            <div className="jumbotron">
                {redirectToAddNewsPage && <Redirect to="/Backoffice/Dashboard/News" />}
                <h1>News</h1>
                {loading ? (
                    <Spinna />
                ) : (
                    <>
                        <button
                          type="button"
                          style={{ marginBottom: 20 }}
                          className="btn btn-outline-info add-news"
                          onClick={() => this.setState({ redirectToAddNewsPage: true })}
                        >
                            ADD NEWS
                        </button>

                        <NewsList
                          onDeleteClick={this.handleDeleteNews}
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
    common: PropTypes.object.isRequired,
    actions: PropTypes.shape({
        loadNewsList: PropTypes.func,
        deleteNews: PropTypes.func,
        clearCommon: PropTypes.func,
    }).isRequired,
    loading: PropTypes.bool.isRequired,
};

function mapStateToProps(state) {
    return {
        newsList: state.newsList.length > 0 ? state.newsList : [],
        common: state.common && state.common.file ? state.common : {},
        loading: state.apiCallsInProgress > 0,
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: {
            loadNewsList: bindActionCreators(newsActions.loadNewsList, dispatch),
            deleteNews: bindActionCreators(newsActions.deleteNews, dispatch),
            clearCommon: bindActionCreators(commonActions.clearCommon, dispatch),
        },
    };
}

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(NewsPage);
