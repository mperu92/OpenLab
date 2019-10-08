import React from 'react';
import PropTypes from 'prop-types';

const SelectInput = ({
    name,
    label,
    onChange,
    defaultOption,
    value,
    error,
    options,
}) => (
        <div className="form-group">
            <label htmlFor={name}>{label}</label>
            <div className="fied">
                {/* Note, value is set here rather than on the option */}
                <select
                  name={name}
                  value={value}
                  onChange={onChange}
                  className="form-control"
                >
                    <option value="">{defaultOption}</option>
                    {options.map((o) => (
                            <option key={o.value} value={o.value}>
                                {o.text}
                            </option>
                        ))}
                </select>
                {error && <div className="alert alert-danger">{error}</div>}
            </div>
        </div>
    );

SelectInput.propTypes = {
    name: PropTypes.string.isRequired,
    label: PropTypes.string.isRequired,
    onChange: PropTypes.func.isRequired,
    defaultOption: PropTypes.string,
    value: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
    error: PropTypes.string,
    options: PropTypes.arrayOf(PropTypes.object),
};

SelectInput.defaultProps = {
    defaultOption: '',
    value: '' || 0,
    error: '',
    options: [],
};

export default SelectInput;
