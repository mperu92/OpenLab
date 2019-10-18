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
        {news.Id ? 'Edit' : 'Add'}
        news
      </h2>
      {errors.onSave && (
        <div className="alert alert-danger" role="alert">
          {errors.onSave}
        </div>
      )}
      <TextInput
        name="Title"
        label="Title"
        value={news.Title}
        onChange={onChange}
        error={errors.Title}
      />

      <TextInput
        name="Abstract"
        label="Abstract"
        value={news.Abstract}
        onChange={onChange}
        error={errors.Abstract}
      />

      <TextInput
        name="BodyHtml"
        label="BodyHtml"
        value={news.BodyHtml}
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
    Id: PropTypes.number,
    Title: PropTypes.string,
    Abstract: PropTypes.string,
    BodyHtml: PropTypes.string,
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
