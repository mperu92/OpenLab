/* eslint-disable react/jsx-props-no-spreading */
import React from 'react';
import PropTypes from 'prop-types';
import {
    Button, Icon, Upload as AntUpload,
} from 'antd';

const Upload = ({
    label,
    error,
    inputName,
    // onSaveFile,
    value,
    savingFile,
    cancelFile,
    ...props
}) => {
    let wrapperClass = 'form-group';
    if (error && error.length > 0) {
      wrapperClass += '  has-error';
    }

    return (
        <div className={wrapperClass}>
          <label htmlFor={inputName}>{label}</label>
          <div className="field">
            {value && value !== '' ? (
                <div>
                    <img src={value} alt="uploaded file" className="mw-15" />
                    &nbsp;&nbsp;&nbsp;
                    <input type="button" value="CANCEL" className="btn btn-info" onClick={() => cancelFile(value)} />
                </div>
            ) : (
                <>
                    <AntUpload {...props}>
                        <Button>
                            <Icon type="upload" />
                            Click to Upload
                        </Button>
                    </AntUpload>
                    {savingFile && <div className="alert alert-info">Saving File...</div>}
                    {error && <div className="alert alert-danger">{error}</div>}
                </>
            )}
            {/* <input type="hidden" value={inputName} name={inputName} /> */}
          </div>
        </div>
      );
  };


Upload.propTypes = {
    label: PropTypes.string.isRequired,
    // onChange: PropTypes.func.isRequired,
    inputName: PropTypes.string.isRequired,
    // onSaveFile: PropTypes.func.isRequired,
    action: PropTypes.func.isRequired,
    cancelFile: PropTypes.func.isRequired,
    placeholder: PropTypes.string,
    value: PropTypes.string,
    fileList: PropTypes.arrayOf(PropTypes.object),
    name: PropTypes.string,
    error: PropTypes.string,
    multiple: PropTypes.bool,
    headers: PropTypes.shape({
        authorization: PropTypes.string,
    }),
    savingFile: PropTypes.bool,
};

Upload.defaultProps = {
    placeholder: '',
    value: '',
    error: '',
    name: 'file',
    fileList: [],
    // action: (file) => Upload.onSaveFile(file),
    multiple: false,
    headers: {
        authorization: 'authorization-text',
    },
    savingFile: false,
};

export default Upload;
