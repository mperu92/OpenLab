import React from 'react';
import PropTypes from 'prop-types';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Redirect } from 'react-router-dom';
import { toast } from 'react-toastify';

import * as newsActions from '../../../redux/actions/newsActions';
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
        const { news, actions } = this.props;
        if (news.length === 0) {
            actions.loadNewsList()
            .catch((error) => {
                toast.error(error);
            });
        }
    }

    handleDeleteNews = async (news) => {
        const { actions } = this.props;
        toast.succcess('News deleted');
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
                {redirectToAddNewsPage && <Redirect to="/news" />}
                <h1>News</h1>
                {loading ? (
                    <Spinna />
                ) : (
                    <>
                        <button
                          type="button"
                          style={{ marginBottom: 20 }}
                          className="btn btn-ptimary add-news"
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
    actions: PropTypes.shape({
        loadNewsList: PropTypes.func,
        deleteNews: PropTypes.func,
    }).isRequired,
    loading: PropTypes.bool.isRequired,
};

function mapStateToProps(state) {
    debugger;
    return {
        newsList: state.news.length > 0 ? state.newsList : [],
        loading: state.apiCallsInProgress > 0,
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: {
            loadNewsList: bindActionCreators(newsActions.loadNewsList, dispatch),
            deleteNews: bindActionCreators(newsActions.deleteNews, dispatch),
        },
    };
}

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(NewsPage);
