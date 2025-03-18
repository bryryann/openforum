import React, { useState } from "react";

type InputTypes = 'text' | 'password';

export const useInput = (type: InputTypes) => {
    const [value, setValue] = useState<string>('');

    const onChange = (e: React.SyntheticEvent) => {
        setValue((e.target as HTMLInputElement).value);
    };

    return {
        value,
        type,
        onChange
    };
};
