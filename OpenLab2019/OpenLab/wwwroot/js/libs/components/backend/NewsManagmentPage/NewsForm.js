import React from 'react';
import PropTypes from 'prop-types';
import TextInput from '../../common/TextInput';
// import SelectInput from '../../common/SelectInput';

const NewsForm = ({
  news,
  onSave,
  onChange,
  saving = false,
  errors = {},
}) => (
    <form onSubmit={onSave}>
      <h2>
        {news.id ? 'EDIT ' : 'ADD '}
        NEWS
      </h2>
      {errors.onSave && (
        <div className="alert alert-danger" role="alert">
          {errors.onSave}
        </div>
      )}
      <TextInput
        name="title"
        label="Title"
        value={news.title}
        onChange={onChange}
        error={errors.Title}
      />

      <TextInput
        name="abstract"
        label="Abstract"
        value={news.abstract}
        onChange={onChange}
        error={errors.Abstract}
      />

      <TextInput
        name="bodyHtml"
        label="BodyHtml"
        value={news.bodyHtml}
        onChange={onChange}
        error={errors.BodyHtml}
      />

      <button type="submit" disabled={saving} className="btn btn-primary">
        {saving ? 'Saving...' : 'Save'}
      </button>
    </form>
);

NewsForm.propTypes = {
  news: PropTypes.shape({
    id: PropTypes.number,
    slug: PropTypes.string,
    title: PropTypes.string,
    abstract: PropTypes.string,
    bodyHtml: PropTypes.string,
    bodyText: PropTypes.string,
    imageUrl: PropTypes.string,
    niceLink: PropTypes.string,
    // eslint-disable-next-line react/forbid-prop-types
    publishDate: PropTypes.any,
    createUserName: PropTypes.string,
    createUserId: PropTypes.number,
    updateUserName: PropTypes.string,
    updateUserId: PropTypes.number,
  }).isRequired,
  errors: PropTypes.shape({
    onSave: PropTypes.string,
    Title: PropTypes.string,
    Abstract: PropTypes.string,
    BodyHtml: PropTypes.string,
  }),
  onSave: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  saving: PropTypes.bool,
};

NewsForm.defaultProps = {
    saving: false,
    errors: {},
};

export default NewsForm;
