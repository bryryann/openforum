import { useRef, useEffect } from 'react';

/**
 * In the attempt of reducing nested elements during routing, this hook will change the className of the 'root' div.
 * This also helps when it comes to styling pages and avoid css properties to affect other unrelated files.
 *
 * @param className {string} - The className that will be attributed to the root div.
 */
export const useRootClass = (className: string) => {
    const root = useRef(document.getElementById('root'));

    useEffect(() => {
        if (root.current) {
            root.current.className = className;
        }
    });
}
