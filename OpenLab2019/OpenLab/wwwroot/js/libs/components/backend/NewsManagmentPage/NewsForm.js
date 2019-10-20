import React from 'react';
import PropTypes from 'prop-types';
import TextInput from '../../common/TextInput';
import TextArea from '../../common/TextArea';
import Upload from '../../common/Upload';
// import SelectInput from '../../common/SelectInput';

const NewsForm = ({
  news,
  onSave,
  onSaveFile,
  onChange,
  onChangeEditor,
  onChangeUploader,
  saving = false,
  savingFile = false,
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
      {errors.onSaveFile && (
        <div className="alert alert-danger" role="alert">
          {errors.onSaveFile}
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

      <Upload
        inputName="imageUrl"
        label="Upload News Cover Image"
        value={news.imageUrl}
        onChange={onChangeUploader}
        action={onSaveFile}
        savingFile={savingFile}
        error={errors.ImageUrl}
      />

      <TextArea
        name="bodyHtml"
        label="Text"
        value={news.bodyHtml}
        onChange={onChangeEditor}
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
    // to fix
    // eslint-disable-next-line react/forbid-prop-types
    publishDate: PropTypes.any,
    createUserName: PropTypes.string,
    createUserId: PropTypes.number,
    updateUserName: PropTypes.string,
    updateUserId: PropTypes.number,
  }).isRequired,
  errors: PropTypes.shape({
    onSave: PropTypes.string,
    onSaveFile: PropTypes.string,
    Title: PropTypes.string,
    Abstract: PropTypes.string,
    BodyHtml: PropTypes.string,
    ImageUrl: PropTypes.string,
  }),
  onSave: PropTypes.func.isRequired,
  onSaveFile: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  onChangeEditor: PropTypes.func.isRequired,
  onChangeUploader: PropTypes.func.isRequired,
  saving: PropTypes.bool,
  savingFile: PropTypes.bool,
};

NewsForm.defaultProps = {
    saving: false,
    savingFile: false,
    errors: {},
};

export default NewsForm;
